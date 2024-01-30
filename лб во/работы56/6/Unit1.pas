unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ExtCtrls, StrUtils, Spin, OleCtrls, SHDocVw, jpeg,
  ComCtrls;

type
  MyFunc = function(x, y: extended): extended;

type
  TForm1 = class(TForm)
    GroupBox1:    TGroupBox;
    GroupBox2:    TGroupBox;
    GroupBox3:    TGroupBox;
    Button1:      TButton;
    RichEdit1:    TRichEdit;
    PageControl1: TPageControl;
    TabSheet2:    TTabSheet;
    Image3:       TImage;
    TabSheet1:    TTabSheet;
    GroupBox5:    TGroupBox;
    EditX0:       TEdit;
    Label8:       TLabel;
    Label9:       TLabel;
    EditY0:       TEdit;
    EditY1:       TEdit;
    Label6:       TLabel;
    Label10:      TLabel;
    EditX1:       TEdit;
    EditY2:       TEdit;
    Label11:      TLabel;
    Label12:      TLabel;
    EditX2:       TEdit;
    GroupBox4:    TGroupBox;
    Label3:       TLabel;
    Label4:       TLabel;
    Label2:       TLabel;
    CheckBox2:    TCheckBox;
    SpinEdit2:    TSpinEdit;
    EditAlpha:    TEdit;
    EditEps:      TEdit;
    EditBeta:     TEdit;
    EditGamma:    TEdit;
    Label1:       TLabel;
    Image1: TImage;
    procedure Button1Click(Sender: TObject);
    procedure EditKeyPress(Sender: TObject; var Key: char);
  private
    procedure Lines(f: myfunc);
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

implementation

uses Math;

const
  X_LEFT = -5;
  X_RIGHT = 5;
  Y_BOTTOM = -5;
  Y_TOP = 5;

{$R *.dfm}

// Вспомогательная функция замены переменной в одних границах на другие ========

function map(x, in_min, in_max, out_min, out_max: extended): extended;
begin
  Result := (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
end;

// Оптимизируемые функции ======================================================

function func1(x, y: extended): extended;
begin
  Result := x*x+0.5*x*x*y*y+x+y*y;

end;

// Методы оптимизации ==========================================================

//Метод Нелдера-Мида
procedure nelder_mead(f: myfunc;
  x0, y0, x1, y1, x2, y2, alpha, beta, gamma, eps: extended; up_to_step: integer;
  stop_flag: boolean; var min_x, min_y: extended);
var
  f0, f1, f2, fh, fg, fl, xh, yh, xg, yg, xl, yl: extended;
  xo, yo, fo, xr, yr, fr, xe, ye, fe, xc, yc, fc: extended;
  sigma, f_: extended;
  k: integer;
begin
  eps := abs(eps);
  k := 1;

  while True do
  begin

    f0 := f(x0, y0);
    f1 := f(x1, y1);
    f2 := f(x2, y2);

    // Максимальная точка
    fh := f0;
    xh := x0;
    yh := y0;
    if f1 > fh then
    begin
      fh := f1;
      xh := x1;
      yh := y1;
    end;
    if f2 > fh then
    begin
      fh := f2;
      xh := x2;
      yh := y2;
    end;

    // Минимальная точка
    fl := f0;
    xl := x0;
    yl := y0;
    if f1 < fl then
    begin
      fl := f1;
      xl := x1;
      yl := y1;
    end;
    if f2 < fl then
    begin
      fl := f2;
      xl := x2;
      yl := y2;
    end;

    // Следующая за максимальной точка
    fg := fl;
    xg := xl;
    yg := yl;
    if (f0 > fg) and (f0 < fh) then
    begin
      fg := f0;
      xg := x0;
      yg := y0;
    end;
    if (f1 > fg) and (f1 < fh) then
    begin
      fg := f1;
      xg := x1;
      yg := y1;
    end;
    if (f2 > fg) and (f2 < fh) then
    begin
      fg := f2;
      xg := x2;
      yg := y2;
    end;

    //Рисуем линию на графике
    with Form1.Image3 do
    begin
      Canvas.Pen.Color := clWhite;
      Canvas.Pen.Width := 2;
      Canvas.MoveTo(Round(map(xl, X_LEFT, X_RIGHT, 0, Width)),
        Height - Round(map(yl, Y_BOTTOM, Y_TOP, 0, Height)));
      Canvas.LineTo(Round(map(xh, X_LEFT, X_RIGHT, 0, Width)),
        Height - Round(map(yh, Y_BOTTOM, Y_TOP, 0, Height)));
      Canvas.LineTo(Round(map(xg, X_LEFT, X_RIGHT, 0, Width)),
        Height - Round(map(yg, Y_BOTTOM, Y_TOP, 0, Height)));
      Canvas.LineTo(Round(map(xl, X_LEFT, X_RIGHT, 0, Width)),
        Height - Round(map(yl, Y_BOTTOM, Y_TOP, 0, Height)));
    end;

    // Поиск центра тяжести точек
    xo := (xl + xg) / 2;
    yo := (yl + yg) / 2;
    fo := f(xo, yo);

    // Отражение
    xr := (1 + alpha) * xo - alpha * xh;
    yr := (1 + alpha) * yo - alpha * yh;
    fr := f(xr, yr);

    if fr < fl then
    begin
      // Растяжение
      xe := gamma * xr + (1 - gamma) * xo;
      ye := gamma * yr + (1 - gamma) * yo;
      fe := f(xe, ye);

      if fe < fl then
      begin
        xh := xe;
        yh := ye;
        fh := fe;
      end else
      begin
        xh := xr;
        yh := yr;
        fh := fr;
      end;
      // А дальше там проверка сходимости
    end
    else if fr > fg then
    begin
      if fr < fh then
      begin
        xh := xr;
        yh := yr;
        fh := fr;
      end;

      xc := beta * xh + (1 - beta) * xo;
      yc := beta * yh + (1 - beta) * yo;
      fc := f(xc, yc);

      if fc < fh then
      begin
        xh := xc;
        yh := yc;
        fh := fc;
        // А дальше там проверка сходимости
      end else
      begin
        xh := (xh + xl) / 2;
        yh := (yh + yl) / 2;
        fh := f(xh, yh);

        xl := (xl + xl) / 2;
        yl := (yl + yl) / 2;
        fl := f(xl, yl);

        xg := (xg + xl) / 2;
        yg := (yg + yl) / 2;
        fg := f(xg, yg);
        // А дальше там проверка сходимости
      end;
    end else
    begin
      xh := xr;
      yh := yr;
      fh := fr;
      // А дальше там проверка сходимости
    end;

    // Проверка сходимости
    f_ := (fh + fg + fl) / 3;
    sigma := sqrt(((fh - f_) * (fh - f_) + (fl - f_) * (fl - f_) + (fg - f_) * (fg - f_)) / 3);

    min_x := xl;
    min_y := yl;

    if sigma < eps then
    begin
      break;
    end;

    x0 := xl;
    y0 := yl;
    x1 := xh;
    y1 := yh;
    x2 := xg;
    y2 := yg;

    //Выводим инфу
    Form1.RichEdit1.Lines.Add(Format('k=%d)'#9'xl=%.6f,'#9'yl=%.6f,'#9'fl=%.6f,'#9'xg=%.6f,'#9'yg=%.6f,'#9'fg=%.6f,'#9'xh=%.6f,'#9'yh=%.6f,'#9'fh=%.6f,'#9'sigma=%.6f',[k,xl,yl,fl,xg,yg,fh,xh,yh,fh,sigma])); //Вывод шагов

    //Условие выхода по окончанию количества шагов
    if (up_to_step > 1) then
      Dec(up_to_step)
    else if stop_flag then
    begin
      Form1.RichEdit1.Lines.Add('Превышено ограничение на количество шагов!');
      break;
    end;

    //Увеличили шаг
    Inc(k);
  end;
  // Отображаем минимум на графике
  with Form1.Image3 do
  begin
    Canvas.Font.Color := clBlue;
    Canvas.TextOut(Round(map(min_x, X_LEFT, X_RIGHT, 0, Width)),
      Height - Round(map(min_y, Y_BOTTOM, Y_TOP, 0, Height)), Format('%f', [f(min_x, min_y)]));
  end;
end;


procedure TForm1.Lines(f: myfunc);
var
  x_step, y_step, f_min, f_max, Value: extended;
  i, j, shade, k: integer;
  flag: boolean;
begin
  // Линии уровня ==============================================================
  x_step := abs(x_right - x_left) / Image3.Width;
  y_step := abs(y_top - y_bottom) / Image3.Height;

  f_min := f(x_left, y_bottom);
  f_max := f(x_left, y_bottom);

  // Поиск минимального и максимального значения в диапазоне
  for i := 0 to Image3.Width - 1 do
    for j := 0 to Image3.Height - 1 do
    begin
      Value := f(x_left + i * x_step, y_bottom + j * y_step);
      if Value < f_min then
        f_min := Value;
      if Value > f_max then
        f_max := Value;
    end;

  // Вывод на экран
  for i := 0 to Image3.Width - 1 do
    for j := 0 to Image3.Height - 1 do
    begin
      Value := f(x_left + i * x_step, y_top - j * y_step);
      shade := Round(map(Value, f_min, f_max, 0, 255));
      Image3.Canvas.Pixels[i, j] := RGB((shade mod 20) * 13, 0, 0);
      {if ((shade mod 20) = 0) then
      begin
        Image3.Canvas.Pixels[i,j] := RGB(0,0,0);
      end;}
    end;

  for k := 0 to 13 do
  begin
    flag := False;
    for i := 0 to Image3.Width - 1 do
      for j := 0 to Image3.Height - 1 do
      begin
        Value := f(x_left + i * x_step, y_top - j * y_step);
        shade := Round(map(Value, f_min, f_max, 0, 255));
        if ((shade mod 20) = 0) and ((shade div 20) = k) then
        begin
          if not flag then
          begin
            Image3.Canvas.Font.Color := clRed;
            Image3.Canvas.TextOut(i, j, Format('%f', [Value]));
            flag := True;
          end;
        end;
      end;
  end;
end;

procedure TForm1.Button1Click(Sender: TObject);
var
  x_min, y_min, x0, y0, x1, y1, x2, y2, alpha, beta, gamma, eps: extended;
  up_to_step: integer;
  stop_flag: boolean;
  f: MyFunc;
begin
  f := func1;
  // Очищаем график и поле вывода
  RichEdit1.Clear;
  // Рисуем линии уровня
  RichEdit1.Lines.Add('Построение линий уровня...');
  Application.ProcessMessages;
  Lines(f);
  Application.ProcessMessages;

  // Выбор параметров для методов поиска минимума
  x0  := StrToFloat(StringReplace(EditX0.Text, '.', DecimalSeparator, []));
  y0  := StrToFloat(StringReplace(EditY0.Text, '.', DecimalSeparator, []));
  x1  := StrToFloat(StringReplace(EditX1.Text, '.', DecimalSeparator, []));
  y1  := StrToFloat(StringReplace(EditY1.Text, '.', DecimalSeparator, []));
  x2  := StrToFloat(StringReplace(EditX2.Text, '.', DecimalSeparator, []));
  y2  := StrToFloat(StringReplace(EditY2.Text, '.', DecimalSeparator, []));
  alpha := StrToFloat(StringReplace(EditAlpha.Text, '.', DecimalSeparator, []));
  beta := StrToFloat(StringReplace(EditBeta.Text, '.', DecimalSeparator, []));
  gamma := StrToFloat(StringReplace(EditGamma.Text, '.', DecimalSeparator, []));
  eps := StrToFloat(StringReplace(EditEps.Text, '.', DecimalSeparator, []));
  up_to_step := SpinEdit2.Value;
  stop_flag := CheckBox2.Checked;

  //Метод Нелдера-Мида =========================================================
  x_min := 0;
  y_min := 0;
  RichEdit1.Lines.Add('Поиск точки минимума методом Нелдера-Мида:');
  nelder_mead(f, x0, y0, x1, y1, x2, y2, alpha, beta, gamma, eps,
    up_to_step, stop_flag, x_min, y_min);

  //Отображение и прокрутка вниз результата ====================================
  RichEdit1.Lines.Add('');
  RichEdit1.Lines.Add('Ответ:'#13#10'x_min = ' + FloatToStr(x_min) +
    #13#10'y_min = ' + FloatToStr(y_min) + #13#10'f_min = ' + FloatToStr(f(x_min, y_min)));
  RichEdit1.SelStart  := Length(RichEdit1.Text);
  RichEdit1.SelLength := 0;
  SendMessage(RichEdit1.Handle, EM_SCROLLCARET, 0, 0);
end;

procedure TForm1.EditKeyPress(Sender: TObject; var Key: char);
begin
  //ShowMessage(IntToStr(Ord(Key)));
  if Key = '.' then
    Key := DecimalSeparator;
  if not (Key in ['0'..'9',  DecimalSeparator, #8]) then
    Key := #0;
end;

end.
