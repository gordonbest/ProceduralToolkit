﻿using System;
using UnityEngine;

namespace ProceduralToolkit
{
    /// <summary>
    /// Representation of 2D vectors and points using integers
    /// </summary>
    [Serializable]
    public struct Vector2Int
    {
        /// <summary>
        /// X component of the vector
        /// </summary>
        public int x;

        /// <summary>
        /// Y component of the vector
        /// </summary>
        public int y;

        #region Static constructors

        /// <summary> 
        /// Shorthand for writing new Vector2Int(0, 0)
        /// </summary>
        public static Vector2Int zero { get { return new Vector2Int(0, 0); } }
        /// <summary> 
        /// Shorthand for writing new Vector2Int(1, 1)
        /// </summary>
        public static Vector2Int one { get { return new Vector2Int(1, 1); } }
        /// <summary> 
        /// Shorthand for writing new Vector2Int(1, 0)
        /// </summary>
        public static Vector2Int right { get { return new Vector2Int(1, 0); } }
        /// <summary> 
        /// Shorthand for writing new Vector2Int(-1, 0)
        /// </summary>
        public static Vector2Int left { get { return new Vector2Int(-1, 0); } }
        /// <summary> 
        /// Shorthand for writing new Vector2Int(0, 1)
        /// </summary>
        public static Vector2Int up { get { return new Vector2Int(0, 1); } }
        /// <summary> 
        /// Shorthand for writing new Vector2Int(0, -1)
        /// </summary>
        public static Vector2Int down { get { return new Vector2Int(0, -1); } }

        #endregion Static constructors

        /// <summary>
        /// Returns the length of this vector (RO)
        /// </summary>
        public float magnitude { get { return Mathf.Sqrt(x*x + y*y); } }

        /// <summary>
        /// Returns the squared length of this vector (RO)
        /// </summary>
        public int sqrMagnitude { get { return x*x + y*y; } }

        /// <summary>
        /// Constructs a new vector with given x, y components
        /// </summary>
        public Vector2Int(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        #region Operators

        public static explicit operator Vector2Int(Vector2 v)
        {
            return new Vector2Int(Mathf.RoundToInt(v.x), Mathf.RoundToInt(v.y));
        }

        public static explicit operator Vector2Int(Vector3 v)
        {
            return new Vector2Int(Mathf.RoundToInt(v.x), Mathf.RoundToInt(v.y));
        }

        public static implicit operator Vector2(Vector2Int v)
        {
            return new Vector2(v.x, v.y);
        }

        public static implicit operator Vector3(Vector2Int v)
        {
            return new Vector3(v.x, v.y, 0);
        }

        public static Vector2Int operator +(Vector2Int a, Vector2Int b)
        {
            return new Vector2Int(a.x + b.x, a.y + b.y);
        }

        public static Vector2Int operator -(Vector2Int a, Vector2Int b)
        {
            return new Vector2Int(a.x - b.x, a.y - b.y);
        }

        public static Vector2Int operator -(Vector2Int a)
        {
            return new Vector2Int(-a.x, -a.y);
        }

        public static Vector2Int operator *(int d, Vector2Int a)
        {
            return new Vector2Int(a.x*d, a.y*d);
        }

        public static Vector2Int operator *(Vector2Int a, int d)
        {
            return new Vector2Int(a.x*d, a.y*d);
        }

        public static Vector2Int operator /(Vector2Int a, int d)
        {
            return new Vector2Int(a.x/d, a.y/d);
        }

        public static bool operator ==(Vector2Int a, Vector2Int b)
        {
            return a.x == b.x && a.y == b.y;
        }

        public static bool operator !=(Vector2Int a, Vector2Int b)
        {
            return !(a == b);
        }

        #endregion Operators

        public override int GetHashCode()
        {
            return x.GetHashCode() ^ (y.GetHashCode() << 2);
        }

        public override bool Equals(object other)
        {
            if (!(other is Vector2Int))
            {
                return false;
            }
            Vector2Int vector2Int = (Vector2Int) other;
            return x.Equals(vector2Int.x) && y.Equals(vector2Int.y);
        }

        /// <summary>
        /// Returns a nicely formatted string for this vector
        /// </summary>
        public override string ToString()
        {
            return string.Format("({0}, {1})", x, y);
        }
    }
}