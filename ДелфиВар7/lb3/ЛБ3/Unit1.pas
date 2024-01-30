unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Math;

type
  TForm1 = class(TForm)
    Edit1: TEdit;
    Label1: TLabel;
    Label2: TLabel;
    Edit2: TEdit;
    Button1: TButton;
    Memo1: TMemo;
    Edit3: TEdit;
    Label3: TLabel;
    Label4: TLabel;
    Edit4: TEdit;
    Memo2: TMemo;
    Button2: TButton;
    Memo3: TMemo;
    Button3: TButton;
    procedure Button1Click(Sender: TObject);
    procedure OnActivate(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure OnKeyPressEdit(Sender: TObject; var Key: Char);
    procedure KeyPressPer(Sender: TObject; var Key: Char);
    procedure Button3Click(Sender: TObject);
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
  VAR
  i,n:Integer;
  y,x:Double;
  p1,p:^Double;
 begin
  Memo1.Clear();
  y:=0;
  x:=StrToFloat(Edit2.Text);
  n:=StrToInt(Edit1.Text);
  p:=VirtualAlloc(nil,4096,MEM_COMMIT,PAGE_READWRITE);
  Edit3.Text:=IntToStr(integer(p));
  p1:=p;
  for i:=1 to n do
  begin
    y:=y+(Power(sin(x),i));
    p^:=y;
    Inc(p);
  end;
  p:=p1;
  y:=0;
  For i:=1 to n do
  begin
    y:=p^;
    memo1.Lines.Add('y['+ IntToStr(i)+'] = '+ FloatToStr(y));
    Inc(p);
  end;
  memo1.Lines.Add('Ответ: ' + FloatToStr(y));
end;

procedure TForm1.OnActivate(Sender: TObject);
begin
  memo1.Clear();
  memo2.Clear();
end;

procedure TForm1.Button2Click(Sender: TObject);
var
  mbi:TMemoryBasicInformation;
  dwRez:DWORD;
  firstAddress: Pointer;
  lastAddress: longword;
  temp1, temp2: int64;
  error: boolean;
begin
  if Edit3.GetTextLen = 0
  then ShowMessage('Введите первый адрес')
  else if Edit4.GetTextLen = 0
  then ShowMessage('Введите второй адрес')
  else
  begin
     Memo2.Clear();
     error:=false;
        temp1:=StrToInt64(Edit3.Text);
        if temp1 > 4294967295 then
        begin
          error:=true;
          ShowMessage('Выход за пределы диапазона для первого адреса!');
        end;
        temp2:=StrToInt64(Edit4.Text);
        if temp2 > 4294967295 then
        begin
          error:=true;
          ShowMessage('Выход за пределы диапазона для второго адреса!');
        end;
     if temp1 >= temp2 then
     begin
        error:=true;
        ShowMessage('Первый адрес должен быть меньше второго!');
     end;
     if not error then
     begin
     firstAddress:= pointer(StrToInt64(Edit3.Text));
     lastAddress:= StrToInt64(Edit4.Text);
     while Integer(firstAddress) < lastAddress do
     begin
        dwRez:=VirtualQuery(firstAddress, mbi, sizeof(MEMORY_BASIC_INFORMATION));
        Memo2.Lines.Add('Начальный адрес: '+IntToStr(integer(mbi.BaseAddress)));
        case mbi.AllocationProtect of
        0: Memo2.Lines.Add('ВАП зарезервировано');
        PAGE_NOACCESS:Memo2.Lines.Add('Атрибут защиты ВАП PAGE_NOACCESS');
        PAGE_READONLY:Memo2.Lines.Add('Атрибут защиты ВАП PAGE_READONLY');
        PAGE_READWRITE:Memo2.Lines.Add('Атрибут защиты ВАП PAGE_READWRITE');
        PAGE_EXECUTE:Memo2.Lines.Add('Атрибут защиты ВАП PAGE_EXECUTE');
        PAGE_EXECUTE_READ:Memo2.Lines.Add('Атрибут защиты ВАП PAGE_EXECUTE_READ');
        PAGE_EXECUTE_READWRITE:Memo2.Lines.Add('Атрибут защиты ВАП PAGE_EXECUTE_READWRITE');
        PAGE_WRITECOPY:Memo2.Lines.Add('Атрибут защиты ВАП PAGE_WRITECOPY');
        PAGE_EXECUTE_WRITECOPY:Memo2.Lines.Add('Атрибут защиты ВАП PAGE_EXECUTE_WRITECOPY');
        end;
        firstAddress:= pointer(Integer(mbi.BaseAddress) + mbi.RegionSize);
        if Integer(firstAddress) < lastAddress
        then Memo2.Lines.Add('Конечный адрес: '+IntToStr(Integer(firstAddress)))
        else Memo2.Lines.Add('Конечный адрес: '+IntToStr(lastAddress));
        Memo2.Lines.Add('');
     end;
     end;
  end;
end;

procedure TForm1.OnKeyPressEdit(Sender: TObject; var Key: Char);
begin
    if (not (Key in ['0','1'..'9'])) and (Key<>#08) then
    Key:=#0;
end;

procedure TForm1.KeyPressPer(Sender: TObject; var Key: Char);
begin
   if (not (Key in ['0','1'..'9'])) and (Key<>#08) and (Key<>',') then
    Key:=#0;
end;

procedure TForm1.Button3Click(Sender: TObject);
VAR
  mbi:TMemoryBasicInformation;
  dwRez, i:DWORD;
begin
  memo3.Clear;
  i:=StrToInt64(Edit3.Text);
  while i < StrToInt64(Edit4.Text) do
  begin
     dwRez:=VirtualQuery(pointer(i),mbi,sizeof(MEMORY_BASIC_INFORMATION));
     if mbi.State = MEM_FREE then Memo3.Lines.Add(IntToStr(i));
     Inc(i,mbi.RegionSize);
  end;
end;

end.
