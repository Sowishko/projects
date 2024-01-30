unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls;

type
  TForm1 = class(TForm)
    Edit1: TEdit;
    Edit2: TEdit;
    procedure Edit1Change(Sender: TObject);
    procedure FormCreate(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  ev: THandle;
  hThread1:THandle;
  pFunc1:pointer;
  ThreadID1:CARDINAL;

implementation

{$R *.dfm}

procedure Thread1;
begin
  { WaitForSingleObject(ev,INFINITE); }
      Form1.Edit2.Text:=Form1.Edit2.Text+'*';
      Form1.Refresh;
    SetEvent(ev);
    Sleep(1);
    ResetEvent(ev);
end;

procedure TForm1.Edit1Change(Sender: TObject);
begin
    pFunc1:=@Thread1;
    hThread1:=CreateThread(nil,0,pFunc1,nil,0,ThreadID1);
end;

procedure TForm1.FormCreate(Sender: TObject);
begin
  Form1.Refresh;
  ev:=CreateEvent(nil,FALSE,FALSE,PChar('CYKABLYAT'));
end;

end.

