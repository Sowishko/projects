unit Unit1;

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
  Sum:Integer; {����������, � ������� ������������ ��������� ���������� }
  f:TextFile;				{�������� ����������}
  cs:TRTLCriticalSection;	{����������� ������}
  mt:THANDLE;			{���������� ������� mutex}
  ev:THANDLE; 			{���������� ������� "�������"}



implementation

{$R *.dfm}

procedure TForm1.Button1Click(Sender: TObject);
var Size: integer;
    hFile,hFileMap: THandle;
  begin
  hFile:=CreateFile('file1.txt',GENERIC_READ, FILE_SHARE_READ, nil, OPEN_EXISTING,FILE_ATTRIBUTE_NORMAL,0);
  Size:=GetFileSize(hFile,nil);
  hFileMap:=CreateFileMapping(hFile,nil,PAGE_READWRITE,0,Size,'RRR');
  mt:=CreateMutex(nil,false,PChar('Send'));
  Edit1.Text:=IntToStr(mt);

  end;

end.
