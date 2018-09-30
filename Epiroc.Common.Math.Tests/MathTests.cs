using Xunit;

namespace Epiroc.Common.Math.Tests
{
    public class MathTests
    {
        [Fact]
        public void Two_different_points_are_not_equal()
        {
            var point1 = new Point2D(1.0, 1.0);
            var point2 = new Point2D(2.0, 2.0);

            Assert.NotEqual(point1, point2);
        }

        [Fact]
        public void Point_is_equal_to_self()
        {
            var point = new Point2D(2.0, 3.0);

            Assert.Equal(point, point);
        }

        [Fact]
        public void Points_with_same_coordinates_are_equal()
        {
            var point1 = new Point2D(1.5, 1.5);
            var point2 = new Point2D(1.5, 1.5);

            Assert.Equal(point1, point2);
        }

        [Fact]
        public void Can_read_X_coordinate()
        {
            var point = new Point2D(1.0, 2.0);

            Assert.Equal(1.0, point.X);
        }

        [Fact]
        public void Can_read_Y_coordinate()
        {
            var point = new Point2D(1.0, 2.0);

            Assert.Equal(2.0, point.Y);
        }

        [Fact]
        public void Can_add_two_vectors()
        {
            var v1 = new Vector2D(1.0, 2.0);
            var v2 = new Vector2D(0.1, 0.3);

            var result = v1 + v2;

            Assert.Equal(new Vector2D(1.1, 2.3), result);
        }

        [Fact]
        public void Subtracting_two_points_creates_a_vector()
        {
            var point1 = new Point2D(2.0, 3.0);
            var point2 = new Point2D(1.0, 1.0);

            var result = point1 - point2;

            Assert.Equal(new Vector2D(1.0, 2.0), result);
        }

        [Fact]
        public void Can_subtract_two_vectors()
        {
            var v1 = new Vector2D(3.0, 4.0);
            var v2 = new Vector2D(2.0, 1.0);

            var result = v1 - v2;
            
            Assert.Equal(new Vector2D(1.0, 3.0), result);
        }

        [Fact]
        public void Can_multiply_a_vector_with_a_scalar()
        {
            var v1 = new Vector2D(-1.0, 2.0);

            var result = 1.5 * v1;

            Assert.Equal(new Vector2D(-1.5, 3.0), result);
        }

        [Fact]
        public void Can_get_vector_length()
        {
            var v = new Vector2D(3.0, 4.0);

            var result = v.Length();

            Assert.Equal(5.0, result);
        }

        [Fact]
        public void Can_get_length_of_line()
        {
            var line = new Line2D(new Point2D(2.0, 2.0), new Point2D(7.0, 14.0));

            var result = line.Length();

            Assert.Equal(13.0, result);
        }
    }
}
