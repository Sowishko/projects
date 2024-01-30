unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ExtCtrls, TeeProcs, TeEngine, Chart, XPMan, ComCtrls,
  Series, StrUtils, Spin, jpeg;

type
  TForm1 = class(TForm)
    GroupBox1: TGroupBox;
    Chart1: TChart;
    GroupBox2: TGroupBox;
    RadioButton1: TRadioButton;
    RadioButton2: TRadioButton;
    GroupBox3: TGroupBox;
    Button1: TButton;
    RichEdit1: TRichEdit;
    Series1: TLineSeries;
    Series2: TLineSeries;
    PageControl1: TPageControl;
    TabSheet2: TTabSheet;
    EditEps1: TEdit;
    SpinEdit2: TSpinEdit;
    CheckBox2: TCheckBox;
    GroupBox4: TGroupBox;
    Label1: TLabel;
    Label2: TLabel;
    EditEps2: TEdit;
    Label3: TLabel;
    Label4: TLabel;
    EditX1: TEdit;
    EditH: TEdit;
    Image1: TImage;
    Image2: TImage;
    procedure Image1Click(Sender: TObject);
    procedure Image2Click(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure EditKeyPress(Sender: TObject; var Key: Char);
  private
    { Private declarations }
  public
    { Public declarations }
  end;
const
  e=2.72;
var
  Form1: TForm1;

implementation

uses Math;

type
  MyFunc = function(x: extended): extended;

{$R *.dfm}

// Оптимизируемые функции ======================================================

function func1(x: extended): extended;
begin
  Result := 2*x*x+3*Math.power(5-x,4/3);
end;

function func2(x: extended): extended;
begin
  Result := -10 * x * math.Log10(exp(1)) + (x*x/2);
end;


// Методы оптимизации ==========================================================

//Метод Пауэлла
function powell(f: myfunc; x0, h, eps1, eps2: extended; up_to_step: integer; stop_flag: boolean): extended;
var
  delta,fdelta,xmin,fxmin,x1,x2,x3,fx1,fx2,fx3,compare1,compare2: extended;
  k: integer;
begin
  h := abs(h);
  eps1 := abs(eps1);
  eps2 := abs(eps2);
  Result := x0;

  //Задаем первую точку
  x1 := x0;
  fx1 := f(x1);

  //Текущий шаг
  k := 1;

  while true do
  begin
    
    //Задаем вторую точку
    x2 := x1 + h;
    fx2 := f(x2);
    
    //Задаем третью точку
    if fx1 > fx2 then x3 := x1 + 2*h else x3 := x1 - h;
    fx3 := f(x3);
    
    //Находим минимум
    xmin := x1; fxmin := fx1;
    if fx2 < fxmin then begin xmin := x2; fxmin := fx2 end;
    if fx3 < fxmin then begin xmin := x3; fxmin := fx3 end;
    
    //Находим delta
    delta := 1/2 * (x1+x2) + 1/2 * ((fx1-fx2)*(x2-x3)*(x3-x1))/((x2-x3)*fx1+(x3-x1)*fx2+(x1-x2)*fx3);
    fdelta := f(delta);

    //Условия окончания
    compare1 := abs((fxmin-fdelta)/fdelta);
    compare2 := abs((xmin-delta)/delta);

    Form1.RichEdit1.Lines.Add(Format('k=%d)'#9'x1=%f,'#9'x2=%f,'#9'x3=%f,'#9'f(x1)=%f,'#9'f(x2)=%f,'#9'f(x3)=%f,'#9'delta=%f,'#9'f(delta)=%f,'#9'compare1=%f,'#9'compare2=%f',[k,x1,x2,x3,fx1,fx2,fx3,delta,fdelta,compare1,compare2])); //Вывод шагов
    
    //Проверка окончания
    if (compare1 < eps1) and (compare2 < eps2) then
    begin
      Result := delta;
      break;
    end;
    
    // Меняем точки
    if (fdelta < fxmin) or (x1 = xmin) then
    begin
      x1 := delta;
      fx1 := fdelta;
    end else
    begin
      x1 := xmin;
      fx1 := fxmin;
    end;
    
    //Условие выхода
    if (up_to_step > 1) then
      dec(up_to_step)
    else if stop_flag then
    begin
      Form1.RichEdit1.Lines.Add('Превышено ограничение на количество шагов!');
      Result := delta;
      break;
    end;
    
    //Увеличили шаг
    inc(k);
    
  end;
end;

// Пользовательский интерфейс ==================================================

procedure TForm1.Button1Click(Sender: TObject);
var
  left, right, step, t, eps1, eps2, x, h, min: extended;
  up_to_step: integer;
  stop_flag: boolean;
  f: MyFunc;
begin
  //Выбираем функцию
  if RadioButton1.Checked then
    f := func1
  else
    f := func2;

  //f := func3;

  // Очищаем график и поле вывода
  Series1.Clear;
  Series2.Clear;
  RichEdit1.Clear;

  // Выбор параметров для методов поиска минимума
  eps1 := StrToFloat(StringReplace(EditEps1.Text,'.',DecimalSeparator,[]));
  eps2 := StrToFloat(StringReplace(EditEps2.Text,'.',DecimalSeparator,[]));
  x := StrToFloat(StringReplace(EditX1.Text,'.',DecimalSeparator,[]));
  h := StrToFloat(StringReplace(EditH.Text,'.',DecimalSeparator,[]));
  up_to_step := SpinEdit2.Value;
  stop_flag := CheckBox2.Checked;
  //min := 0;

  //Метод Пауэлла
  RichEdit1.Lines.Add('Поиск точки минимума методом Пауэлла:');
  min := powell(f, x, h, eps1, eps2, up_to_step, stop_flag);

  //Отображение и прокрутка вниз результата

  RichEdit1.Lines.Add('Ответ: min=' + FloatToStr(min) + '; f(min)='+FloatToStr(f(min)));
  RichEdit1.SelStart := Length(RichEdit1.Text);
  RichEdit1.SelLength := 0;

  right := min+0.1;
  left := min-0.1;
  step := ((right - left) / 50);
  t := left;
  while t <= right do
  begin
    Series1.AddXY(t,f(t));
    t := t + step;
  end;

  Series2.AddXY(min,Series1.MaxYValue);
  Series2.AddXY(min,Series1.MinYValue);
  SendMessage(RichEdit1.Handle, EM_SCROLLCARET, 0, 0);
end;

procedure TForm1.EditKeyPress(Sender: TObject; var Key: Char);
begin
  //ShowMessage(IntToStr(Ord(Key)));
  if Key = '.' then Key := DecimalSeparator;
  if not (Key in ['0'..'9','-',DecimalSeparator,#8]) then Key := #0;
end;

procedure TForm1.Image1Click(Sender: TObject);
begin
  RadioButton1.SetFocus;
  RadioButton1.Checked := True;
end;

procedure TForm1.Image2Click(Sender: TObject);
begin
  RadioButton2.SetFocus;
  RadioButton2.Checked := True;
end;

end.
