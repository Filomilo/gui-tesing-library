# Plan interfejsów

## Przykłady bibliotek do testowania GUI

###  Cypress 

Jest to narzędzie do przeprowadzania testów typu E2E na apliacjach webowych

Ze względu na możliwość znajdwania elemntów za pomocą pszeszukiwanai elemntów html i wyknywania na nich operacji
``` javascript
 cy.get('[data-cy="new-todo"]').type('write tests{enter}')
```

każdy taki elemnt posiaada opcje should dzięki ktremu dokonuje się sprawdzenia poprawności danego elementu
``` javascript
cy.get('button').should('contains.text', 'Click me!')
```

### Selenium
Podobnie jak w przpypadku Cypress pozwala na testowania aplikacji webowych. Selenium dosepne jest w większej ilości języków jak programowani jak Java python czy c#.

podbnie jak w w przypadku Cypress zjadywane obiekty maja funkcje do obsługi co ułtatiwa skladanie elemntów

```java
driver.findElement(By.name("user_name")).sendKeys("userName");
    driver.findElement(By.name("password")).sendKeys("my supersecret password");
    driver.findElement(By.name("sign-in")).click();
```
w przypadku wykywania asercji ma metode przyjmującą obiekt i metode do jej sprawdzenia

```java
    assertThat(driver.findElement(By.tagName("h1")).getText(), is("Hello userName"));
```

### SikuliX

Jest to potezna bilitoeka do autmatyzjaci aby sterować komputerme, jest zintegorowany w wielu jezykach i środowiksah i posiada opvje porówynyania obrazów, detekcji obiektów na obrazie i wykrywania tesktu

Skullic posaida włąsne ide i własny system skryptów do autamtyzacji
``` 
click(Photo of input box)
wait(Till this screen appear)
type(String input with action defined as Key.ENTER)
```



## Plany intefejsów do obsługi systemu

### System - Singleton
* GetSystemVersion
* StartProces
* GetClipBoard
* GetActiveWindows
* GetWindowByName
* GetProcessByName
* GetActiveProcesses
* 

### Screen
* GetSize
* GetScreenshot
* GetScreenShotRect
* GetPixelColorAt


### WIndow: Screen
* GetPostion
* SetPSotion
* MoveWindow
* Minimize
* Maximize
* GetProcesOFWinwo
* DoesWindwoExist
* GetName
* Close


### Mouse
* MoveMouse
* SetPostion
* GetPosition
* ClickLEft
* ClickRigt
* ClickMIddle
* PresLeft
* PressMiddle
* PressRight
* UnPressLeft
* UnpressMiddle
* UnpressRight
* Scrollup
* ScrollDown
* MoveRelativeToWindow

### KeyBoard
* Press (KEY)
* UnPress(Key)
* Click(Key)
* Type(String)


### Process 
* GetProcesName
* GetWindowsOfProcess
* GetRamUsageOfProcess
* IsProcessAlive
* Kill

### ScreenShot
* ComapreToImage
* SaveImage
* CropImage
* DetectTextOnImage