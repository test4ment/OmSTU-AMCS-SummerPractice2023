namespace SalonLib.Test;

public class ServiceLocatorTest
{
<<<<<<< HEAD

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

    [Fact]
    public void Service2Test()
    {
        var expected = "У рояля";
        var actual = SalonLib.ServiceLocator.GetService("Петь романсы");
        Assert.Equal(expected, actual);
    }
}
>>>>>>> f7069dd (Добавлен тест для сервиса 1)
=======
    [Fact]
    public void Service3Test()
    {
        var expected = "В кабинете";
        var actual = SalonLib.ServiceLocator.GetService("Писать статьи");
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Service4Test()
    {
        var expected = "За карточным столом";
        var actual = SalonLib.ServiceLocator.GetService("Играть в карты");
        Assert.Equal(expected, actual);
    }
}
>>>>>>> fa9148d (Добавлен тест для сервиса 3)
