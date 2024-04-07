using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;

namespace LogicCorrupt.Utilidades
{
    public static class LogicMaths
    {
        internal static readonly List<Vector2> Direciones = new List<Vector2>()
        {
            new Vector2(-1f, -1f),
            new Vector2(1f, -1f),
            new Vector2(-1f, 1f),
            new Vector2(1f, 1f),
            new Vector2(0f, -1f),
            new Vector2(-1f, 0f),
            new Vector2(0f, 1f),
            new Vector2(1f, 0f),
        };

        public static float PerlinNoise2D(float x, float y, int octaves, int seed)
        {
            float SmoothFunction(float n) => 3f * n * n - 2f * n * n * n;
            float NoiseGradient(int s, int noiseX, int noiseY, float xd, float yd)
            {
                int hash = s;
                hash ^= 1619 * noiseX;
                hash ^= 31337 * noiseY;
                hash = hash * hash * hash * 60493;
                Vector2 g = Direciones[hash & 7];
                return xd * g.X + (yd * g.Y);
            }
            int frecuencia = (int)Math.Pow(2D, octaves);
            x *= frecuencia;
            y *= frecuencia;
            int flooredX = (int)x;
            int flooredY = (int)y;
            int ceilingX = flooredX + 1;
            int ceilingY = flooredY + 1;
            float interpolatedX = x - flooredX;
            float interpolatedY = y - flooredY;
            float interpolatedX2 = interpolatedX - 1;
            float interpolatedY2 = interpolatedY - 1;

            float fadeX = SmoothFunction(interpolatedX);
            float fadeY = SmoothFunction(interpolatedY);

            float smoothX = MathHelper.Lerp(NoiseGradient(seed, flooredX, flooredY, interpolatedX, interpolatedY), NoiseGradient(seed, ceilingX, flooredY, interpolatedX2, interpolatedY), fadeX);
            float smoothY = MathHelper.Lerp(NoiseGradient(seed, flooredX, ceilingY, interpolatedX, interpolatedY2), NoiseGradient(seed, ceilingX, ceilingY, interpolatedX2, interpolatedY2), fadeX);
            return MathHelper.Lerp(smoothX, smoothY, fadeY);
        }

        public static float AperiodicSin(float x, float dx = 0f, float a = MathHelper.Pi, float b = MathHelper.E)
        {
            return (float)(Math.Sin(x * a + dx) + Math.Sin(x * b + dx)) * 0.5f;
        }
        public static float Manhattandistancia(this Vector2 a, Vector2 b) => Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
        public static float WrapAngle90grados(float theta)
        {
            // Ensure that the angle starts off in the -180 to 180 degree range instead of the 0 to 360 degree range.
            if (theta > MathHelper.Pi)
                theta -= MathHelper.Pi;

            if (theta > MathHelper.PiOver2)
                theta -= MathHelper.Pi;
            if (theta < -MathHelper.PiOver2)
                theta += MathHelper.Pi;

            return theta;
        }
        public static float AngleBetween(this Vector2 v1, Vector2 v2) => (float)Math.Acos(Vector2.Dot(v1.SafeNormalize(Vector2.Zero), v2.SafeNormalize(Vector2.Zero)));
        public static Vector2 GetProjectilePhysicsFiringVelocity(Vector2 shootingPosition, Vector2 destination, float gravity, float shootSpeed, Vector2? nanFallback = null)
        {
            gravity = -Math.Abs(gravity);

            float horizontalRange = MathHelper.Distance(shootingPosition.X, destination.X);
            float fireAngleSine = gravity * horizontalRange / (float)Math.Pow(shootSpeed, 2);

            if (nanFallback is null)
                fireAngleSine = MathHelper.Clamp(fireAngleSine, -1f, 1f);

            float fireAngle = (float)Math.Asin(fireAngleSine) * 0.5f;

            if (float.IsNaN(fireAngle))
                return nanFallback.Value * shootSpeed;

            Vector2 fireVelocity = new Vector2(0f, -shootSpeed).RotatedBy(fireAngle);
            fireVelocity.X *= (destination.X - shootingPosition.X < 0).ToDirectionInt();
            return fireVelocity;
        }
        public static float ShortestDistanceToLine(this Vector2 point, Vector2 lineStart, Vector2 lineEnd)
        {
            Vector2 lineVector = lineEnd - lineStart;
            Vector2 perpendicular = lineVector.RotatedBy(MathHelper.PiOver2);
            Vector2 pointToOrigin = point - lineStart;

            return (float)Math.Abs((pointToOrigin.X * perpendicular.X + pointToOrigin.Y * perpendicular.Y)) / perpendicular.Length();
        }
        public static Vector2 ClosestPointOnLine(this Vector2 point, Vector2 lineStart, Vector2 lineEnd)
        {

            Vector2 perpendicular = (lineEnd - lineStart).RotatedBy(MathHelper.PiOver2).SafeNormalize(Vector2.Zero);
            float distanceToLine = point.ShortestDistanceToLine(lineStart, lineEnd);
            float lineSide = Math.Sign((point.X - lineStart.X) * (-lineEnd.Y + lineStart.Y) + (point.Y - lineStart.Y) * (lineEnd.X - lineStart.X));

            return point + distanceToLine * lineSide * perpendicular;
        }
        public static float Modulo(this float dividend, float divisor)
        {
            return dividend - (float)Math.Floor(dividend / divisor) * divisor;
        }
        /// <summary>
        /// Clamps the magnitude of a vector via safe normalization.
        /// </summary>
        /// <param name="v">The vector.</param>
        /// <param name="min">The minimum magnitude.</param>
        /// <param name="max">The maximum magnitude.</param>
        public static Vector2 ClampMagnitude(this Vector2 v, float min, float max) => v.SafeNormalize(Vector2.UnitY) * MathHelper.Clamp(v.Length(), min, max);

        /// <summary>
        /// Gives the angle in radians between two other angles
        /// This function exists for vectors but somehow is missing for floats
        /// </summary>
        /// <param name="angle">Your source angle</param>
        /// <param name="otherAngle">The target angle</param>
        /// <returns></returns>
        public static float AngleBetween(this float angle, float otherAngle) => ((otherAngle - angle) + MathHelper.Pi).Modulo(MathHelper.TwoPi) - MathHelper.Pi;

        /// <summary>
        /// Gets the sign of the number, but without the zero case. If 0 is inputted into this method, 1 is returned/
        /// </summary>
        /// <param name="x">The input value.</param>
        public static int DirectionalSign(this float x) => (x > 0f).ToDirectionInt();

        /// <summary>
        /// Gets a value from 0 to 1 and returns an eased value.
        /// </summary>
        /// <param name="amount">How far along the easing are we</param>
        /// <returns></returns>
        public delegate float EasingFunction(float amount, int degree);

        public static float LinearEasing(float amount, int degree) => amount;
        //Sines
        public static float SineInEasing(float amount, int degree) => 1f - (float)Math.Cos(amount * MathHelper.Pi / 2f);
        public static float SineOutEasing(float amount, int degree) => (float)Math.Sin(amount * MathHelper.Pi / 2f);
        public static float SineInOutEasing(float amount, int degree) => -((float)Math.Cos(amount * MathHelper.Pi) - 1) / 2f;
        public static float SineBumpEasing(float amount, int degree) => (float)Math.Sin(amount * MathHelper.Pi);
        //Polynomials
        public static float PolyInEasing(float amount, int degree) => (float)Math.Pow(amount, degree);
        public static float PolyOutEasing(float amount, int degree) => 1f - (float)Math.Pow(1f - amount, degree);
        public static float PolyInOutEasing(float amount, int degree) => amount < 0.5f ? (float)Math.Pow(2, degree - 1) * (float)Math.Pow(amount, degree) : 1f - (float)Math.Pow(-2 * amount + 2, degree) / 2f;
        //Exponential
        public static float ExpInEasing(float amount, int degree) => amount == 0f ? 0f : (float)Math.Pow(2, 10f * amount - 10f);
        public static float ExpOutEasing(float amount, int degree) => amount == 1f ? 1f : 1f - (float)Math.Pow(2, -10f * amount);
        public static float ExpInOutEasing(float amount, int degree) => amount == 0f ? 0f : amount == 1f ? 1f : amount < 0.5f ? (float)Math.Pow(2, 20f * amount - 10f) / 2f : (2f - (float)Math.Pow(2, -20f * amount - 10f)) / 2f;
        //circular
        public static float CircInEasing(float amount, int degree) => (1f - (float)Math.Sqrt(1 - Math.Pow(amount, 2f)));
        public static float CircOutEasing(float amount, int degree) => (float)Math.Sqrt(1 - Math.Pow(amount - 1f, 2f));
        public static float CircInOutEasing(float amount, int degree) => amount < 0.5 ? (1f - (float)Math.Sqrt(1 - Math.Pow(2 * amount, 2f))) / 2f : ((float)Math.Sqrt(1 - Math.Pow(-2f * amount - 2f, 2f)) + 1f) / 2f;


        public enum EasingType //Potion seller. I need your strongest ease ins
        {
            Linear,
            SineIn, SineOut, SineInOut, SineBump,
            PolyIn, PolyOut, PolyInOut,
            ExpIn, ExpOut, ExpInOut,
            CircIn, CircOut, CircInOut
        }

        private static readonly EasingFunction[] EasingTypeToFunction = new EasingFunction[] { LinearEasing, SineInEasing, SineOutEasing, SineInOutEasing, SineBumpEasing, PolyInEasing, PolyOutEasing, PolyInOutEasing, ExpInEasing, ExpOutEasing, ExpInOutEasing, CircInEasing, CircOutEasing, CircInOutEasing };

        /// <summary>
        /// This represents a part of a piecewise function.
        /// </summary>
        public struct CurveSegment
        {
            /// <summary>
            /// This is the type of easing used in the segment
            /// </summary>
            public EasingFunction easing;
            /// <summary>
            /// This indicates when the segment starts on the animation
            /// </summary>
            public float startingX;
            /// <summary>
            /// This indicates what the starting height of the segment is
            /// </summary>
            public float startingHeight;
            public float elevationShift;
            public int degree;

            public float EndingHeight => startingHeight + elevationShift;

            public CurveSegment(EasingType MODE, float startX, float startHeight, float elevationShift, int degree = 1) :
                this(EasingTypeToFunction[(int)MODE], startX, startHeight, elevationShift, degree)
            { }

            public CurveSegment(EasingFunction MODE, float startX, float startHeight, float elevationShift, int degree = 1)
            {
                easing = MODE;
                startingX = startX;
                startingHeight = startHeight;
                this.elevationShift = elevationShift;
                this.degree = degree;
            }
        }

        public static float PiecewiseAnimation(float progress, params CurveSegment[] segments)
        {
            if (segments.Length == 0)
                return 0f;

            if (segments[0].startingX != 0) //If for whatever reason you try to not play by the rules, get fucked
                segments[0].startingX = 0;

            progress = MathHelper.Clamp(progress, 0f, 1f); //Clamp the progress
            float ratio = 0f;

            for (int i = 0; i <= segments.Length - 1; i++)
            {
                CurveSegment segment = segments[i];
                float startPoint = segment.startingX;
                float endPoint = 1f;

                if (progress < segment.startingX) 
                    continue;

                if (i < segments.Length - 1)
                {
                    if (segments[i + 1].startingX <= progress) 
                        continue;
                    endPoint = segments[i + 1].startingX;
                }

                float segmentLength = endPoint - startPoint;
                float segmentProgress = (progress - segment.startingX) / segmentLength; //How far along the specific segment
                ratio = segment.startingHeight;

                if (segment.easing != null)
                    ratio += segment.easing(segmentProgress, segment.degree) * segment.elevationShift;

                else
                    ratio += LinearEasing(segmentProgress, segment.degree) * segment.elevationShift;

                break;
            }
            return ratio;
        }
    }
}
