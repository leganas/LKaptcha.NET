# LKaptcha.NET fork Kaptcha.NET
[![Original](https://github.com/twsl/Kaptcha.NET)]
LKaptcha.NET is simple captcha library for .NET 5 projects.


## Мотивация
Google's [reCAPTCHA](https://en.wikipedia.org/wiki/ReCAPTCHA) Будучи фактически стандартным решением для капчи в наши дни, оно практически не уважает конфиденциальность. Оно собирает значительный объем информации, которая может быть использована для отслеживания пользователей, что значительно усложняет соблюдение GDPR.
Поэтому я хотел создать минималистичное решение, уважающее конфиденциальность, простое в реализации, но достаточно сложное в решении.


## Примеры
| | | | |
|-|-|-|-|
|![alt-text-1](./img/1.png "Example 1") | ![alt-text-2](./img/2.png "Example 2") | ![alt-text-3](./img/3.png "Example 3") | ![alt-text-4](./img/4.png "Example 4") |
|![alt-text-5](./img/5.png "Example 5") | ![alt-text-6](./img/6.png "Example 6") | ![alt-text-7](./img/7.png "Example 7") | ![alt-text-8](./img/8.png "Example 8") |


## Установка
Install the nuget package `LKaptcha.NET`.


## Для начала
* Добавьте необходимые сервисы капчи через расширение коллекции сервисов. Вам потребуется использовать поставщик кэша. Вы можете использовать кэш SQL Server, кэш в оперативной памяти или распределенный кэш (например, Redis).
```csharp
public void ConfigureServices(IServiceCollection services)
{
	//...
	services.AddDistributedMemoryCache(); // Required for the specific default implementation of ICaptchaStorageService
	services.AddCatpcha(Configuration);
	//...
}
```

* Если вы предпочитаете создавать и использовать собственную, пользовательскую реализацию любого сервиса, замените '.AddCatpcha(Configuration)' следующим кодом и используйте свои собственные классы:
```csharp
public void ConfigureServices(IServiceCollection services)
{
	//...
	services.AddCatpchaOptions(configuration);
			.AddCaptchaFontGenerator<FontGeneratorService>();
			.AddCaptchaEffect<EffectGeneratorService>();
			.AddCaptchaKeyGenerator<KeyGeneratorService>();
			.AddCatpchaGenerator<CaptchaGeneratorService>();
			.AddCaptchaStorage<CaptchaStorageService>();
			.AddCaptchaValidator<CaptchaValidationService>();
			.AddScoped(typeof(ValidateCaptchaFilter));
	//...
}
```

* Add the TagHelper to the `_ViewImports.cshtml`
```csharp
@addTagHelper *, LKaptcha.NET
```

* На самом деле, добавить капчу на страницу просмотра после этого очень просто:
```html
<captcha />
```

* Если вы хотите предоставить прямую ссылку на капчу, добавьте новый контроллер и наследуйте его от `Controllers\CaptchaController.cs`, который предоставляет все необходимые методы.
```razor
@{
	var captcha = await generator.CreateCaptchaAsync();
}
<captcha captcha-link="/captcha/@captcha.Id" captcha-id="@captcha.Id" />
```

* Или же вы можете использовать контроллер и действия вместо прямой ссылки и позволить TagHelper генерировать капчу самостоятельно.
```html
<captcha asp-controller="Home" asp-action="GetCaptcha" />
```


## Конфигурация
Вы можете настроить следующие параметры:

* Image height (default: `250`)
* Image Width (default: `100`)
* Scaling (default: `2`)
* Background color (default: `Color.White`)
* Foreground color (default: `Color.Black`)
* Number of characters (default: `5 - 8`)
* Charset (default: `"abcdefghijklmnopqrstuvwxyz"`)
* Rotation angle (default: `-30 - 30`)
* Imageformt (default: `PNG`)
* Validation Timeout (default: `5min`)
* Font family (default: `Arial`)
* Font size (default: `22 - 30`)
* Font style (default: `regular`)

Чтобы изменить значения по умолчанию, необходимо установить соответствующие параметры в одном из разделов `CaptchaOptions` или `FontOptions`.
Кроме того, вы можете включить различные эффекты в разделе `EffectOptions`.

* `BlobEffect`
* `BoxEffect`
* `LineEffect`
* `NoiseEffect`
* `RippleEffect`
* `WaveEffect`
