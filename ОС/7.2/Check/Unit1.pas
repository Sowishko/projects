unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls;

type
  TForm1 = class(TForm)
    Button1: TButton;
    Memo1: TMemo;
    Memo2: TMemo;
    procedure FormCreate(Sender: TObject);
    procedure Button1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  hThread1,hThread2:THandle;
  pFunc1,pFunc2:pointer;
  ThreadID1,ThreadID2:CARDINAL;
  sum:integer;
  ev:THandle;


implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
begin
  Memo1.Clear;
  Memo2.Clear;
end;

procedure Thread1;
begin
  While Sum <20 do
  begin
    WaitForSingleObject(ev,INFINITE);
    Inc(Sum);
    Form1.Memo1.Lines.Add(IntToStr(sum));
    Form1.Refresh;
    SetEvent(ev);
    Sleep(500);
  end;
end;

procedure Thread2;
begin
  While Sum <20 do
  begin
    WaitForSingleObject(ev,INFINITE);
    Inc(Sum);
    Form1.Memo2.Lines.Add(IntToStr(sum));
    Form1.Refresh;
    SetEvent(ev);
    Sleep(500);
  end;
end;


procedure TForm1.Button1Click(Sender: TObject);
begin
  Sum:=0;
  Form1.Refresh;
  ev:=CreateEvent(nil,FALSE,TRUE,PChar(''));
  pFunc1:=@Thread1;
  pFunc2:=@Thread2;
  hThread1:=CreateThread(nil,0,pFunc1,nil,0,ThreadID1);
  hThread2:=CreateThread(nil,0,pFunc2,nil,0,ThreadID2);
end;

end.
