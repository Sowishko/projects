unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, Grids, Tlhelp32, StdCtrls;

type
  TForm1 = class(TForm)
    StringGrid1: TStringGrid;
    Button1: TButton;
    procedure FormCreate(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  pe32: tProcessEntry32;
  hProcess: THandle;
implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
var
  x: Integer;
  mbi:TMemoryBasicInformation;
  dwRez:DWORD;
  p: int64;
  sch: longword;
  hProcess2: THandle;
begin
   StringGrid1.Cells[0,0]:='�';
   StringGrid1.Cells[1,0]:='��� �����';
   StringGrid1.Cells[2,0]:='������������� ��������';
   StringGrid1.Cells[3,0]:='���������� �������';
   StringGrid1.Cells[4,0]:='������� ���������';
   StringGrid1.Cells[5,0]:='���������� ����������������� �������';
   pe32.dwSize:=SizeOf(tProcessEntry32);
   x:=1;
   hProcess:=CreateToolhelp32SnapShot(TH32CS_SNAPPROCESS,0);
   Process32First(hProcess,pe32);
   Repeat
      StringGrid1.Cells[0,x]:=IntToStr(x);
      StringGrid1.Cells[1,x]:=pe32.szExeFile;
      StringGrid1.Cells[2,x]:=IntToStr(pe32.th32ProcessID);
      StringGrid1.Cells[3,x]:=IntToStr(pe32.cntThreads);
      StringGrid1.Cells[4,x]:=IntToStr(pe32.pcPriClassBase);
      p:=0;
      sch:=0;
      hProcess2:=OpenProcess(PROCESS_QUERY_INFORMATION,true,pe32.th32ProcessID);
      if hProcess2 <> 0 then
      begin
      while(p < 4294967295) do
      begin
         dwRez:=VirtualQueryEx(hProcess2,pointer(p),mbi,sizeof(MEMORY_BASIC_INFORMATION));
         if mbi.State = MEM_RESERVE then
         sch:=sch+mbi.RegionSize div 4096;
         if dwRez <> 0 then
         p:=longword(mbi.BaseAddress)+mbi.RegionSize
         else
         p:=p+4096;
      end;
      end;
      StringGrid1.Cells[5,x]:=IntToStr(sch);
      x:=x+1;
      StringGrid1.RowCount:=x;
   until Process32Next(hProcess,pe32)=False;
end;

procedure TForm1.Button1Click(Sender: TObject);
begin
    Form1.OnCreate(Sender);
end;

procedure TForm1.FormClose(Sender: TObject; var Action: TCloseAction);
begin
   Closehandle(hProcess);
end;

end.
