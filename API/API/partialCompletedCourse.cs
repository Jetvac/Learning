using API.Models;

namespace API.Models
{
    partial class CompletedCourse
    {
        public string EducationOrganisationName
        {
            get
            {
                try
                {
                    return new LearningContext().EducationOrganisations.Where(e => e.EducationOrganisationId == this.EducationOrganisationId).First().EducationOrganisationName;
                }
                catch (Exception)
                {
                    return "";
                }
            }
        }
    }
}
