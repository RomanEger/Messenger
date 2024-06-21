using Domain.Entities;

namespace UnitTests;

public class TestUserSetData
{
    [Theory]
    [InlineData("gmail@gmail.com")]
    [InlineData("fsfs@mail.ru")]
    //сюда еще несколько вариантов нужно закинуть, которые должны быть валидными
    public void Test_ValidEmail(string email)
    {
        var user = new User()
        {
            Email = email
        };
        Assert.Equal(user.Email, email);
    }
    
    [Theory]
    [InlineData("gmail#gmail.com")]
    [InlineData("fsfs@mailru")]
    //сюда еще несколько вариантов нужно закинуть, которые должны быть невалидными
    public void Test_InvalidEmail(string email)
    {
        var user = new User()
        {
            Email = email
        };
        Assert.NotEqual(user.Email, email);
    }
    
}