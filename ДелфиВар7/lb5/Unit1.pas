unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, ExtCtrls, StdCtrls;

type
  TForm1 = class(TForm)
    Image1: TImage;
    Image2: TImage;
    Edit1: TEdit;
    Button1: TButton;
    Button2: TButton;
    Button3: TButton;
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
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

procedure Thread1;
begin
  Form1.Image1.Canvas.Ellipse(0,0,100,50);
end;

procedure Thread2;
begin
  Form1.Image2.Canvas.Rectangle(0,0,100,50);
end;

procedure Thread3;
begin
  Form1.Edit1.Text:=IntToStr(random(100));
end;

procedure TForm1.Button1Click(Sender: TObject);
var pFunc:Pointer;
    ThreadID:CARDINAL;
    hThread:THandle;
begin
  pFunc:=@Thread1;
  hThread:=CreateThread(nil,0,pFunc,nil,0,ThreadID);
end;

procedure TForm1.Button2Click(Sender: TObject);
var pFunc:Pointer;
    ThreadID:CARDINAL;
    hThread:THandle;
begin
  pFunc:=@Thread2;
  hThread:=CreateThread(nil,0,pFunc,nil,0,ThreadID);
end;

procedure TForm1.Button3Click(Sender: TObject);
var pFunc:Pointer;
    ThreadID:CARDINAL;
    hThread:THandle;
begin
  pFunc:=@Thread3;
  hThread:=CreateThread(nil,0,pFunc,nil,0,ThreadID);
end;

end.
