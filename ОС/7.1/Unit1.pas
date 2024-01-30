unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls;

type
  TForm1 = class(TForm)
    Edit1: TEdit;
    Button1: TButton;
    Edit2: TEdit;
    procedure Button1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  pFile:PChar;
  mt: THandle;
  f: TextFile;

implementation

{$R *.dfm}




procedure TForm1.Button1Click(Sender: TObject);
var pFunc:pointer;
    hThread: THandle;
    ThreadID1: Cardinal;
    hFileMappingObject: THandle;
begin
    mt:=OpenMutex(MUTEX_ALL_ACCESS,false,PChar('Send'));
    Edit2.Text:=IntToStr(mt);

    hFileMappingObject:=OpenFileMapping(FILE_MAP_ALL_ACCESS,false,'RRR');
    WaitForSingleObject(mt,INFINITE);


    pFile:=MapViewOfFile(hFileMappingObject,FILE_MAP_ALL_ACCESS,0,0,0);
    Edit1.Text:=pFile;
    ReleaseMutex(mt);
end;

end.
