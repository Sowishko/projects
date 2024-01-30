unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ExtCtrls, TeeProcs, TeEngine, Chart, XPMan, ComCtrls,
  Series, StrUtils, Spin, OleCtrls, SHDocVw, jpeg;

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
    EditX0:       TEdit;
    SpinEdit2:    TSpinEdit;
    CheckBox2:    TCheckBox;
    GroupBox4:    TGroupBox;
    Label1:       TLabel;
    Label2:       TLabel;
    EditDelta:    TEdit;
    Label3:       TLabel;
    Label4:       TLabel;
    EditAlpha:    TEdit;
    EditEps:      TEdit;
    Image3:       TImage;
    EditY0:       TEdit;
    Label5:       TLabel;
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

//Метод Хука-Дживса
procedure hook_jives(f: myfunc; delta, alpha, eps: extended;
  up_to_step: integer; stop_flag: boolean; var x, y: extended);
var
  f_old: extended;
  sign_x, sign_y, k: integer;
  new_direction: boolean;
begin
  delta := abs(delta);
  alpha := abs(alpha);
  eps := abs(eps);
  new_direction := True;
  sign_x := 1;
  sign_y := 1;
  k := 0;

  while True do
  begin
    f_old := f(x, y);

    //Выводим инфу
    Form1.RichEdit1.Lines.Add(
      Format('k=%d)'#9'x=%.6f,'#9'y=%.6f,'#9'f(x,y)=%.6f,'#9'delta=%.6f,'#9'new_direction=%d', [k, x, y, f_old, delta, integer(new_direction)])); //Вывод шагов

    //Рисуем линию на графике
    with Form1.Image3 do
    begin
      Canvas.Pen.Color := clWhite;
      Canvas.Pen.Width := 2;
      Canvas.MoveTo(Round(map(x, X_LEFT, X_RIGHT, 0, Width)),
        Height - Round(map(y, Y_BOTTOM, Y_TOP, 0, Height)));
    end;

    //Движение по старому направлению
    if (not new_direction) then
    begin
      if f(x + delta * sign_x, y + delta * sign_y) >= f_old then
      begin
        new_direction := True;
      end else
      begin
        x := x + delta * sign_x;
        y := y + delta * sign_y;
      end;
    end;

    // Выбор нового направления
    if (new_direction) then
    begin
      //Переменная x
      sign_x := 1;
      if f(x + delta * sign_x, y) >= f_old then
        sign_x := -1;
      if f(x + delta * sign_x, y) >= f_old then
        sign_x := 0;
      x := x + delta * sign_x;
      //Переменная y
      sign_y := 1;
      if f(x, y + delta * sign_y) >= f_old then
        sign_y := -1;
      if f(x, y + delta * sign_y) >= f_old then
        sign_y := 0;
      y := y + delta * sign_y;
      //Сменили направление
      new_direction := False;
      //Если направление не сменилось
      if (sign_x = 0) and (sign_y = 0) then
      begin
        new_direction := True;
        delta := delta / alpha;
        if delta < eps then
          break;
      end;
    end;

    //Рисуем линию на графике
    with Form1.Image3 do
      Canvas.LineTo(Round(map(x, X_LEFT, X_RIGHT, 0, Width)),
        Height - Round(map(y, Y_BOTTOM, Y_TOP, 0, Height)));

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
    Canvas.TextOut(Round(map(x, X_LEFT, X_RIGHT, 0, Width)),
      Height - Round(map(y, Y_BOTTOM, Y_TOP, 0, Height)), Format('%f', [f(x, y)]));
  end;
end;

// Пользовательский интерфейс ==================================================
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
  x_min, y_min, x0, y0, delta, alpha, eps: extended;
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
  delta := StrToFloat(StringReplace(EditDelta.Text, '.', DecimalSeparator, []));
  alpha := StrToFloat(StringReplace(EditAlpha.Text, '.', DecimalSeparator, []));
  eps := StrToFloat(StringReplace(EditEps.Text, '.', DecimalSeparator, []));
  up_to_step := SpinEdit2.Value;
  stop_flag := CheckBox2.Checked;

  //Метод Пауэлла ==============================================================
  x_min := x0;
  y_min := y0;
  RichEdit1.Lines.Add('Поиск точки минимума методом Хука-Дживса:');
  hook_jives(f, delta, alpha, eps, up_to_step, stop_flag, x_min, y_min);

  //Отображение и прокрутка вниз результата ====================================
  RichEdit1.Lines.Add('');
  RichEdit1.Lines.Add('Ответ:'#13#10'x_min = ' + FloatToStr(x_min) +
    #13#10'y_min = ' + FloatToStr(y_min) + #13#10'f_min = ' +
    FloatToStr(f(x_min, y_min)));
  RichEdit1.SelStart  := Length(RichEdit1.Text);
  RichEdit1.SelLength := 0;
  SendMessage(RichEdit1.Handle, EM_SCROLLCARET, 0, 0);
end;

procedure TForm1.EditKeyPress(Sender: TObject; var Key: char);
begin
  //ShowMessage(IntToStr(Ord(Key)));
  if Key = '.' then
    Key := DecimalSeparator;
  if not (Key in ['0'..'9', '-', DecimalSeparator, #8]) then
    Key := #0;
end;


end.
