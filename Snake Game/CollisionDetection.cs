using System;
using System.Collections.Generic;
using System.Text;


using SFML;
using SFML.System;

namespace Snake_Game
{
    class CollisionDetection
    {
		private Vector2f getRectangleCenter(Vector2f obj, int width, int height)
		{
			obj.X += width / 2;
			obj.Y += height / 2;
			return obj;
		}
		public bool IsCollide(Vector2f obj1, Vector2f obj2)
        {
            double distanceBWCenter;
			//Hence two rectanglular pixels starts colliding only when they posses distance
			//between center is less than pixel_width
			double collidingDistance = Config.PIXEL_HEIGHT;  //Pixel_Width and Pixel_Height are same
			obj1 = this.getRectangleCenter(obj1, Config.PIXEL_WIDTH, Config.PIXEL_HEIGHT );
			obj2 = this.getRectangleCenter(obj2, Config.PIXEL_WIDTH, Config.PIXEL_HEIGHT );
			distanceBWCenter = Math.Abs(Math.Sqrt(Math.Pow((obj2.X - obj1.X), 2) + Math.Pow((obj2.Y - obj1.Y), 2)));
			if (distanceBWCenter >= collidingDistance)
				return false;
			else
				return true;
		}
    }
}
