using System.Runtime.InteropServices;
using Domain.Entities;

namespace UnitTests;

public class TestUserSetData
{
    [Theory]
    [InlineData("JohnMiller@gmail.com")]
    [InlineData("FedorSachkov@mail.ru")]
    [InlineData("VadimIvanenkov@yandex.ru")]
    [InlineData("Danon@outlook.com")]
    [InlineData("MaxBytovskiy@inbox.ru")]
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
    [InlineData("Georgey@yandex.r")]
    [InlineData("Artur231$inbox.ru")]
    [InlineData("Natan@ramblerri")]
    [InlineData("Vira23#ok.ru")]
    public void Test_InvalidEmail(string email)
    {
        var user = new User()
        {
            Email = email
        };
        Assert.NotEqual(user.Email, email);
    }

    [Theory]
    [InlineData("@rfdjfrA231")]
    [InlineData("@uerse3423A")]
    [InlineData("@Awfqcds23")]
    [InlineData("@Nsawe324")]
    [InlineData("@Ldser52")]
    public void Test_ValidUserName(string userName)
    {
        var user = new User()
        {
            UserName = userName
        };
        Assert.NotEqual(user.UserName, userName);
    }

    [Theory]
    [InlineData("asdfdsD@")]
    [InlineData("@g")]
    [InlineData("@roman4k/")]
    [InlineData(null)]
    [InlineData("12pl]-=`")]
    [InlineData("@12")]
    [InlineData("@dsffdg231423#&@*$&@")]
    public void Test_InvalidUserName(string userName)
    {
        var user = new User()
        {
            UserName = userName
        };
        Assert.NotEqual(user.UserName, userName);
    }
    
    [Theory]
    [InlineData("rfdjfrA231")]
    [InlineData("@uerse3423A")]
    [InlineData("Awf0-=qcds23")]
    [InlineData("@N_12/sawe324")]
    [InlineData("@Ldse#ds`r52")]
    public void Test_ValidNickName(string nickName)
    {
        var user = new User()
        {
            NickName = nickName
        };
        Assert.NotEqual(user.NickName, nickName);
    }

    [Theory]
    [InlineData("@g")]
    [InlineData(null)]
    [InlineData("12")]
    public void Test_InvalidNickName(string nickName)
    {
        var user = new User()
        {
            NickName = nickName
        };
        Assert.NotEqual(user.NickName, nickName);
    }
    
    [Theory]
    [InlineData("+79513121243")]
    [InlineData("+79509858746")]
    [InlineData("+79335769267")]
    [InlineData("+71234569856")]
    [InlineData("+79567216784")]
    public void Test_ValidPhoneNumber(string phoneNumber)
    {
        var user = new User()
        {
            PhoneNumber = phoneNumber
        };
        Assert.NotEqual(user.PhoneNumber, phoneNumber);
    }

    [Theory]
    [InlineData("-7913byd6412")]
    [InlineData("#q9129841278")]
    [InlineData("=75421672839")]
    [InlineData("+01111101018")]
    [InlineData("$951g7691023")]
    public void Test_InvalidPhoneNumber(string phoneNumber)
    {
        var user = new User()
        {
            PhoneNumber = phoneNumber
        };
        Assert.NotEqual(user.PhoneNumber, phoneNumber);
    }

    [Theory]
    [InlineData("rfdjfr@A231")]
    [InlineData("uerse@3423!A")]
    [InlineData("Awfqcds@#!23")]
    [InlineData("Nsawe324!@#")]
    [InlineData("Ldser52#@$")]
    public void Test_ValidPassword(string password)
    {
        var user = new User()
        {
            Password = password
        };
        Assert.NotEqual(user.Password, password);
    }

    [Theory]
    [InlineData("asdfdsD#$%")]
    [InlineData("g")]
    [InlineData(null)]
    [InlineData("1223445")]
    [InlineData("12S")]
    [InlineData("dsffdg231423#&@*$&@")]
    public void Test_InvalidPassword(string password)
    {
        var user = new User()
        {
            Password = password
        };
        Assert.NotEqual(user.Password, password);
    }

}