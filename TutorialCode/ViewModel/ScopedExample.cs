using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialCode.ViewModel
{
    public interface ISingltonExample
    {
        string Id { get; }
    }
    public class ScopedExample
    {
        public ScopedExample()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; }
    }

    public class TransientExample
    {
        public TransientExample()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; }
    }

    public class SingltonExample : ISingltonExample
    {
        public SingltonExample()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; }
    }

    public class RequestExample
    {
        public RequestExample()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; }
    }
}
