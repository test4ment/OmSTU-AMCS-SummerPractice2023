namespace SalonLib.Test;

public class ServiceLocatorTest
{
<<<<<<< HEAD

}
=======
    [Fact]
    public void Service1Test()
    {
        var expected = "В читальном зале";
        var actual = SalonLib.ServiceLocator.GetService("Читать стихи");
        Assert.Equal(expected, actual);
    }
}
>>>>>>> f7069dd (Добавлен тест для сервиса 1)
