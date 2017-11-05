# CaptchaGenerator | Work in progress

## Usage
```
var Generator = new CaptchaGenerator();
picturebox.Image = Generator.GenerateCaptcha(Difficulties.Hard).Image;
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
