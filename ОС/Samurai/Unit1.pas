unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls;

type
  TForm1 = class(TForm)
    Button1: TButton;
    Edit1: TEdit;
    Label1: TLabel;
    Label2: TLabel;
    procedure Button1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  j:integer;

implementation

{$R *.dfm}

procedure Work;
begin
j:=33;
while j<102 do
begin
  case j of
  33: begin j:=j*2;  Form1.Edit1.Text:='Младший ученик'; end;
  66: begin j:=j+33; Form1.Edit1.Text:='Старший ученик'; end;
  99: begin j:=j+1;  Form1.Edit1.Text:='Мастер'; end;
  end;
  if j=100 then
  begin
    Form1.Label2.Caption:='Дело сделано';
    break;
  end;
  Sleep(1000);
end;
end;

procedure TForm1.Button1Click(Sender: TObject);
var pFunc:Pointer;
    ThreadID: Cardinal;
    hThread:THandle;
begin
  pFunc:=@Work;
  hThread:=CreateThread(nil,0,pFunc,nil,0,ThreadID);
end;

end.
