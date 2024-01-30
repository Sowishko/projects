unit Server;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls;

type
  TForm1 = class(TForm)
    Button1: TButton;
    Edit1: TEdit;
    procedure Button1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  mt:THANDLE;
  f:TextFile;
  Str:PChar;

implementation

{$R *.dfm}

procedure Thread1;

begin
  WaitForSingleObject(mt,INFINITE);
  Writeln(f,Str);
  ReleaseMutex(mt);
  Sleep(20);
  CloseFile(f);
end;


procedure TForm1.Button1Click(Sender: TObject);
var
      hThread1,hThread2:THandle;
      pFunc1,pFunc2:pointer;
      ThreadID1,ThreadID2:CARDINAL;
begin

  Str:=PChar(Edit1.Text+#0);

  AssignFile(f,'D:\Serv.txt'); //�������� �� ���� ����
  Rewrite(f);

  //�������� mutex
  mt:=CreateMutex(nil,FALSE,'Serv');

  pFunc1:=@Thread1;
  hThread1:=CreateThread(nil,0,pFunc1,nil,0,ThreadID1);



end;

end.
