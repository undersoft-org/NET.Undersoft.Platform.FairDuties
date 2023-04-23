using RadicalR;

namespace Undersoft.ODP.Api
{

    public class Option : Dto
    {
        public string Name { get; set; }

        public string Data { get; set; }

        public string TypeName { get; set; }

        public object Value { get; set; }
    }
}