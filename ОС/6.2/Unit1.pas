unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms, Dialogs, Grids, StdCtrls, Buttons, tlhelp32;

type
  TForm1 = class(TForm)
    Button1: TButton;
    StringGrid1: TStringGrid;
    StringGrid2: TStringGrid;
    procedure FormCreate(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure StringGrid1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  pe32:tProcessEntry32;
  te32:TThreadEntry32;
  me32:tModuleEntry32;
  hProcess:THandle;
  hThread:THandle;


implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
VAR
  x,code:Integer;
  s:String;
begin
  StringGrid1.Cells[0,0]:='�';
  StringGrid1.Cells[1,0]:='��� �����';
  StringGrid1.Cells[2,0]:='������������� ��������';
  StringGrid1.Cells[3,0]:='���������� �������';
  StringGrid1.Cells[4,0]:='������� ���������';
  pe32.dwSize:=SizeOf(tProcessEntry32);
  x:=1;
  hProcess:=CreateToolhelp32SnapShot(TH32CS_SNAPPROCESS,0);
  Process32First(hProcess,pe32);
{  str(pe32.th32ProcessID,StringGrid1.Cells[2,x]);
  val(StringGrid1.Cells[2,x],pe32.th32ProcessID,code);}
  {str(pe32.th32ProcessID,s);
  val(s,pe32.th32ProcessID,code);  }
  Repeat
    StringGrid1.Cells[0,x]:=IntToStr(x);
    StringGrid1.Cells[1,x]:=pe32.szExeFile;
    StringGrid1.Cells[2,x]:=IntToStr(pe32.th32ProcessID);
    StringGrid1.Cells[3,x]:=IntToStr(pe32.cntThreads);
    StringGrid1.Cells[4,x]:=IntToStr(pe32.pcpriClassBase);
    x:=x+1;
    StringGrid1.RowCount:=x;
  until Process32Next(hProcess,pe32)=False;
end;


procedure TForm1.Button1Click(Sender: TObject);
begin
  Form1.Close;
end;

procedure TForm1.StringGrid1Click(Sender: TObject);
var Id:integer;
    x:integer;
    hSnapshot: THandle;

begin
    x:=1;
    Id:=StrToInt64(StringGrid1.Cells[2, StringGrid1.Row]);

    te32.dwSize:=SizeOf(THREADENTRY32);
    hSnapshot:=CreateToolhelp32SnapShot(TH32CS_SNAPTHREAD,0);
    Thread32First(hSnapshot ,te32);
    Repeat
      begin
        if Id=te32.th32OwnerProcessID then
          begin
            StringGrid2.Cells[0,x]:=IntToStr(x);
            StringGrid2.Cells[1,x]:=IntToStr(te32.th32ThreadID);
            x:=x+1;
            StringGrid2.RowCount:=x;
          end;
      end;
  until Thread32Next(hSnapshot,te32)=false;
end;

end.
