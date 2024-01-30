unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls;

type
  TForm1 = class(TForm)
    Button1: TButton;
    Edit1: TEdit;
    Memo1: TMemo;
    Memo2: TMemo;
    Label1: TLabel;
    Edit2: TEdit;
    procedure Button1Click(Sender: TObject);
    procedure FormActivate(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

implementation

{$R *.dfm}

procedure TForm1.Button1Click(Sender: TObject);
var
  p, p1: ^Real;
  s: Real;
  i, count: Integer;
  mbi: TMemoryBasicInformation;
  dwRez: DWORD;
begin
  Memo1.Clear;
  Memo2.Clear;
  S := 0;
  i := 0;
  count := 0;
  p := VirtualAlloc(nil, 1024, MEM_COMMIT, PAGE_READWRITE);
  //Сохранение начального адреса региона в переменной p1
  p1 := p;

  // Запись в регион результатов вычисления
  while i <= 100 do
  begin
    s := s - sqrt(i);
    p^ := s;
    i := i + 2;
    Inc(p);
  end;

  Edit1.Text := FloatToStr(s);

  // Восстановление начального адреса региона
  p := p1;
  i := 0;

  while i <= 100 do
  begin
    s := p^;
    Memo1.Lines.Add(FloatToStr(s));
    i := i + 2;
    Inc(p);
  end;

  // Восстановление начального адреса региона
  p := p1;
  i := 0;

  while i<=4096 do
  begin
    dwRez := VirtualQuery(p, mbi, sizeof(MEMORY_BASIC_INFORMATION));
    case mbi.AllocationProtect of
      0: Memo2.Lines.Add('ВАП зарезервировано');
      PAGE_NOACCESS: Memo2.Lines.Add('Атрибут защиты ВАП PAGE_NOACCESS');
      PAGE_READONLY: Memo2.Lines.Add('Атрибут защиты ВАП PAGE_READONLY');
      PAGE_READWRITE:
        begin
          Memo2.Lines.Add('Атрибут защиты ВАП PAGE_READWRITE');
          count := count + 1;
        end;
      PAGE_EXECUTE: Memo2.Lines.Add('Атрибут защиты ВАП PAGE_EXECUTE');
      PAGE_EXECUTE_READ:
        Memo2.Lines.Add('Атрибут защиты ВАП PAGE_EXECUTE_READ');
      PAGE_EXECUTE_READWRITE:
        Memo2.Lines.Add('Атрибут защиты ВАП PAGE_EXECUTE_READWRITE');
      PAGE_WRITECOPY: Memo2.Lines.Add('Атрибут защиты ВАП PAGE_WRITECOPY');
      PAGE_EXECUTE_WRITECOPY:
        Memo2.Lines.Add('Атрибут защиты ВАП PAGE_EXECUTE_WRITECOPY');
    end;
    Inc(i);
    Inc(p, 4096);
  end;

  Edit2.Text:=IntToStr(count);

end;

procedure TForm1.FormActivate(Sender: TObject);
begin
  Memo1.Clear;
  Memo2.Clear;
end;

end.

