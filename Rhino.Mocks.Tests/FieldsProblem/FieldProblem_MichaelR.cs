using MbUnit.Framework;
using Rhino.Mocks.Interfaces;

namespace Rhino.Mocks.Tests.FieldsProblem
{
	[TestFixture]
	public class PropertyWithTypeParameterTest
	{
		[Test]
		public void CreatedClosedGenericType()
		{
			MockRepository mocks = new MockRepository();
			mocks.CreateMock<ClosedGenericType>();
		}


		[Test]
		public void UsingdoOnMethodWithGenericReturnValue()
		{
			MockRepository mocks = new MockRepository();
			IGenericType<object> mock =
				mocks.CreateMock<IGenericType<object>>();
			IMethodOptions methodOptions = Expect.Call(mock.MyMethod());
			methodOptions.Do((MyDelegate)delegate{ return new object (); });
		}
	}

	public interface IGenericType<T>
	{
		T MyMethod();
	}

	public delegate object MyDelegate();

	public class ClosedGenericType : OpenGenericType<TypeParameterType>
	{
		public override TypeParameterType GenericProperty
		{
			get { return null; }
		}
	}

	public abstract class OpenGenericType<T>
	{
		public abstract T GenericProperty { get; }
	}

	public class TypeParameterType
	{
	}
}