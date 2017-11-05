# CaptchaGenerator | Work in progress!

## Usage
Simply make an instance of the Captcha class with its text and difficulty. Example:
```
var Captcha = new Captcha("Test Captcha", Difficulties.Hard);
picturebox.Image = Captcha.GenerateCaptcha();
```

## Difficulties
- Easy
  - [x] Text
  - [ ] Lines
  - [ ] Ovals
  - [ ] Random background
- Normal
  - [x] Text
  - [x] Lines
  - [ ] Ovals
  - [ ] Random background
- Hard
  - [x] Text
  - [x] Lines
  - [x] Ovals
  - [ ] Random background
- Unsolvable
  - [x] Text
  - [x] Lines
  - [x] Ovals
  - [x] Random background (perlin noise)

### PerlinNoise.cs
https://lotsacode.wordpress.com/2010/02/24/perlin-noise-in-c/
