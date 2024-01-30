unit Client;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls;

type
  TForm1 = class(TForm)
    Button1: TButton;
    Memo1: TMemo;
    procedure Button1Click(Sender: TObject);
    procedure FormCreate(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  mt:Thandle;
  f:TextFile;
  buf: string[80];

implementation

{$R *.dfm}

procedure Thread3;
begin
  WaitForSingleObject(mt,INFINITE);
  while not EOF(f) do
  begin
    readln(f, buf);
  end;
  ReleaseMutex(mt);
  Sleep(20);
  CloseFile(f);
end;


procedure TForm1.Button1Click(Sender: TObject);
var hThread3:THandle;
    pFunc3:pointer;
     ThreadID3:CARDINAL;

begin
    Memo1.Clear();
    mt:=OpenMutex(MUTEX_ALL_ACCESS, FALSE,'Servv');

    WaitForSingleObject(mt,INFINITE);
    AssignFile(f,'D:\Serv.txt'); //�������� �� ���� ����
    Reset(f);
  
    pFunc3:=@Thread3;
    hThread3:=CreateThread(nil,0,pFunc3,nil,0,ThreadID3);

    Memo1.Lines.Add(buf);
end;

procedure TForm1.FormCreate(Sender: TObject);
begin
  Memo1.Clear();
end;

end.
