using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace Neoris.Ionleap.Business.Logic.UnitTests.Infrastructure
{
    public abstract class TestBase<T>
    {
        protected T Target
        {
            get;
            set;
        }

        protected TestBase()
        {
        }

        [TestInitialize]
        public virtual void Init()
        {
        }

        [TestCleanup]
        public virtual void Cleanup()
        {
        }
    }
}
