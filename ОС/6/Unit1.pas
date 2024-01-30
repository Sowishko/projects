unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, Grids, StdCtrls, Buttons, tlhelp32;

type
  TForm1 = class(TForm)
    StringGrid1: TStringGrid;
    Edit1: TEdit;
    Edit2: TEdit;
    Edit3: TEdit;
    procedure FormCreate(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  pe32: tProcessEntry32;
  me32: tModuleEntry32;
  hProcess, hProcess1: THandle;

implementation

{$R *.dfm}

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

procedure TForm1.FormCreate(Sender: TObject);
var
  x, code, i, j: Integer;
  s: string;
  index: array[1..70] of Integer;
begin
  StringGrid1.Cells[0, 0] := '№';
  StringGrid1.Cells[1, 0] := 'Имя файла';
  StringGrid1.Cells[2, 0] := 'Идентификатор процесса';
  StringGrid1.Cells[3, 0] := 'Количество потоков';
  StringGrid1.Cells[4, 0] := 'Базовый приоритет';
  pe32.dwSize := SizeOf(tProcessEntry32);

  hProcess1 := CreateToolhelp32SnapShot(TH32CS_SNAPPROCESS, 0);
  hProcess := hProcess1;
  Process32First(hProcess1, pe32);
  {  str(pe32.th32ProcessID,StringGrid1.Cells[2,x]);
    val(StringGrid1.Cells[2,x],pe32.th32ProcessID,code);}
  str(pe32.th32ProcessID, s);
  val(s, pe32.th32ProcessID, code);
  i := 1;
  repeat
    index[i] := Integer(pe32.cntThreads);
    i := i + 1;
  until Process32Next(hProcess, pe32) = False;

  Edit1.Text:=IntToStr(index[1]);
  BubbleSort(index);
  Edit2.Text:=IntToStr(index[1]);
  Process32First(hProcess1, pe32);
  hProcess := hProcess1;
  x := 1;
  j := 1;

  repeat
    if Int(pe32.cntThreads) = index[j] then
    begin
      StringGrid1.Cells[0, x] := IntToStr(x);
      StringGrid1.Cells[1, x] := pe32.szExeFile;
      StringGrid1.Cells[2, x] := IntToStr(pe32.th32ProcessID);
      StringGrid1.Cells[3, x] := IntToStr(pe32.cntThreads);
      StringGrid1.Cells[4, x] := IntToStr(pe32.pcpriClassBase);
      x := x + 1;
      j:=j+1;
      StringGrid1.RowCount := x;
    end;
    if j=4 then break
  until Process32Next(hProcess, pe32) = False;

end;

end.

