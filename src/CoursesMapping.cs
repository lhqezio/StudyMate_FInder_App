using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudyMate
{
    public class CoursesMapping
    {
        public int Id { get; set; }

        public Courses Course { get; set; }

        // Add foreign keys for many-to-many relationship
        [ForeignKey("Profile")]
        public string ProfileId { get; set; }
        
        public CoursesMapping()
        {
        }

        public CoursesMapping(Courses course)
        {
            Course = course;
        }
    }
}
