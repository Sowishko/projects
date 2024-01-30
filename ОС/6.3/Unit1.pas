unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms, Dialogs, Grids, StdCtrls, Buttons,tlhelp32;

type
  TForm1 = class(TForm)
    StringGrid1: TStringGrid;
    Button1: TButton;
    Button2: TButton;
    StringGrid2: TStringGrid;
    procedure FormCreate(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure StringGrid1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  pe32:tProcessEntry32;
  te32:tThreadEntry32;
  me32:tModuleEntry32;
  hProcess:THandle;
  hSnapshot: THandle;


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
  te32.dwSize:=SizeOf(THREADENTRY32);
  hSnapshot:=CreateToolhelp32SnapShot(TH32CS_SNAPTHREAD,0);
  Process32First(hProcess,pe32);
{  str(pe32.th32ProcessID,StringGrid1.Cells[2,x]);
  val(StringGrid1.Cells[2,x],pe32.th32ProcessID,code);}
  str(pe32.th32ProcessID,s);
  val(s,pe32.th32ProcessID,code);
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

procedure BubbleSort(var Vetor: array of Integer);
var
  i, temp: Integer;
  changed: Boolean;
begin
  changed := True;
  while changed do
  begin
    changed := False;
    for i := Low(Vetor) to High(Vetor) - 1 do
    begin
      if (Vetor[i] < Vetor[i + 1]) then
      begin
        temp := Vetor[i + 1];
        Vetor[i + 1] := Vetor[i];
        Vetor[i] := temp;
        changed := True;
      end;
    end;
  end;
end;

procedure TForm1.Button2Click(Sender: TObject);
var ThreadCount: array [1..150] of integer;
    x:integer;
    check:bool;
    k1,k2,k3:integer;
    n,i,j:integer;
    s:string;
begin

    //������ � ������ ���������� ������� � ���������
    Process32First(hProcess,pe32);
    x:=1;
    Repeat
      ThreadCount[x]:=pe32.cntThreads;
      x:=x+1;
    until Process32Next(hProcess,pe32)=False;

    //���������� �� ��������
    BubbleSort(ThreadCount);

    //
    k1:=0; k2:=0; k3:=0;
    x:=1;
    check:=true;
    while check do
      begin
        if ThreadCount[x]<1000 then
          begin
            k1:=ThreadCount[x];
            k2:=ThreadCount[x+1];
            k3:=ThreadCount[x+2];
            check:=false;
          end
        else x:=x+1;
      end;

    //
    {Edit1.Text:=IntToStr(k1) + ' ' + IntToStr(k2) + ' '+ IntToStr(k3);  }

    //
    x:=1;
    Process32First(hProcess,pe32);
  Repeat
    if ((pe32.cntThreads=k1) or (pe32.cntThreads=k2) or (pe32.cntThreads=k3)) then
      begin
        StringGrid1.Cells[0,x]:=IntToStr(x);
        StringGrid1.Cells[1,x]:=pe32.szExeFile;
        StringGrid1.Cells[2,x]:=IntToStr(pe32.th32ProcessID);
        StringGrid1.Cells[3,x]:=IntToStr(pe32.cntThreads);
        StringGrid1.Cells[4,x]:=IntToStr(pe32.pcpriClassBase);
        x:=x+1;
        StringGrid1.RowCount:=x;
      end;
  until Process32Next(hProcess,pe32)=False;

  s:=StringGrid1.Cells[3,3];
  StringGrid1.Cells[3,3]:=StringGrid1.Cells[3,2];
  StringGrid1.Cells[3,2]:=s;

end;

procedure TForm1.StringGrid1Click(Sender: TObject);
var Id:integer;
    x:integer;

begin
    StringGrid2.Cells[0,0]:='�';
    StringGrid2.Cells[1,0]:='�������������';
    x:=1;
    Id:=StrToInt64(StringGrid1.Cells[2, StringGrid1.Row]);

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
