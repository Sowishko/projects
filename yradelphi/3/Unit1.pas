unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls;

type
  TForm1 = class(TForm)
    Button1: TButton;
    Label1: TLabel;
    Edit2: TEdit;
    Memo2: TMemo;
    Button2: TButton;
    Memo3: TMemo;
    Label2: TLabel;
    procedure Button1Click(Sender: TObject);
    procedure FormActivate(Sender: TObject);
    procedure Button2Click(Sender: TObject);
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

  Memo2.Clear;
  S := 0;
  i := 0;
  count := 0;
  p := VirtualAlloc(nil, 1024, MEM_COMMIT, PAGE_READWRITE);
  //Сохранение начального адреса региона в переменной p1

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

  Memo2.Clear;
  Memo3.Clear;
end;

procedure TForm1.Button2Click(Sender: TObject);
VAR
i:Integer;
z,x:real;
p,p1:^real;
begin
x:=5;
p:=VirtualAlloc(nil,4096,MEM_COMMIT,PAGE_READWRITE);
p1:=p;
while (x<7) do
begin
z:=sqrt((x+3)/(x-3));
x:=x+0.1;
p^:=z;
Inc(p);
end;
p:=p1;
z:=0;
For i:=1 to 20 do
begin
z:=p^;
Memo3.Lines.Add(FloatToStr(z)); Inc(p);
end;

end;

end.

