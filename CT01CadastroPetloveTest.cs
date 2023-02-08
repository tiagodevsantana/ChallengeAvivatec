
public class SuiteTests : IDisposable {
  public IWebDriver driver {get; private set;}
  public IDictionary<String, Object> vars {get; private set;}
  public IJavaScriptExecutor js {get; private set;}
  public SuiteTests()
  {
    driver = new ChromeDriver();
    js = (IJavaScriptExecutor)driver;
    vars = new Dictionary<String, Object>();
  }
  public void Dispose()
  {
    driver.Quit();
  }

  [Fact]
  public void CT01CadastroPetlove() {

    //Acesso ao site da Petlove
    
    driver.Navigate().GoToUrl("https://www.petlove.com.br/");
    driver.Manage().Window.Size = new System.Drawing.Size(1382, 736);

    //Inicio da criação do cadastro
    
    driver.FindElement(By.CssSelector(".header-item__user > .col")).Click();
    Assert.Equal(driver.FindElement(By.Id("create-account-button")).Text, "Crie uma agora!");
    driver.FindElement(By.Id("create-account-button")).Click();

    //Validação dos campos do cadastro
    {
      IReadOnlyCollection<IWebElement> elements = driver.FindElements(By.Id("email"));
      Assert.True(elements.Count > 0);
    }
    {
      IReadOnlyCollection<IWebElement> elements = driver.FindElements(By.Id("first-name"));
      Assert.True(elements.Count > 0);
    }
    {
      IReadOnlyCollection<IWebElement> elements = driver.FindElements(By.Id("last-name"));
      Assert.True(elements.Count > 0);
    }
    {
      IReadOnlyCollection<IWebElement> elements = driver.FindElements(By.Id("document"));
      Assert.True(elements.Count > 0);
    }
    {
      IReadOnlyCollection<IWebElement> elements = driver.FindElements(By.Id("phone"));
      Assert.True(elements.Count > 0);
    }
    {
      IReadOnlyCollection<IWebElement> elements = driver.FindElements(By.Id("password"));
      Assert.True(elements.Count > 0);
    }
    Assert.Equal(driver.FindElement(By.CssSelector(".form-button--fixed:nth-child(6)")).Text, "Criar minha conta");

  //Preenchimento dos campos

    driver.FindElement(By.Id("email")).SendKeys("tiagoteste100@gmail.com");
    driver.FindElement(By.Id("first-name")).SendKeys("Tiago");
    driver.FindElement(By.Id("last-name")).SendKeys("Santana");
    driver.FindElement(By.Id("document")).SendKeys("85671294002");
    driver.FindElement(By.Id("phone")).SendKeys("71999999999");
    driver.FindElement(By.Id("password")).SendKeys("Petlove123*");
    driver.FindElement(By.Id("submit-btn")).Click();

  //Login na plataforma Petlove
    
    driver.Navigate().GoToUrl("https://www.petlove.com.br/");
    driver.Manage().Window.Size = new System.Drawing.Size(1382, 736);
    driver.FindElement(By.type("email")).SendKeys("tiagoteste100@gmail.com");
    driver.FindElement(By.name("password")).SendKeys("Petlove123*");
    
  }
}
