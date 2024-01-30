unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ExtCtrls;

type
  TFirst1 = class(TForm)
    Edit1: TEdit;
    Button2: TButton;
    Button1: TButton;
    procedure Button2Click(Sender: TObject);
    procedure Button1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  First1: TFirst1;
  ev: THandle;
  str:string;
  hThread1:THandle;
  pFunc1:pointer;
  ThreadID1:CARDINAL;

implementation

{$R *.dfm}

procedure Thread1;
begin
while true do
begin
    WaitForSingleObject(ev,INFINITE);
      First1.Edit1.Text:=First1.Edit1.Text+('*');
      First1.Refresh;
    SetEvent(ev);
    Sleep(10);
end;
end;

procedure TFirst1.Button2Click(Sender: TObject);
begin
  CloseHandle(ev);
  First1.Close;
end;

procedure TFirst1.Button1Click(Sender: TObject);
begin
  ev:=OpenEvent(EVENT_ALL_ACCESS,FALSE,PChar('CYKABLYAT'));
  if ev<>0 then
    begin
      pFunc1:=@Thread1;
      hThread1:=CreateThread(nil,0,pFunc1,nil,0,ThreadID1);
    end;
end;

end.
