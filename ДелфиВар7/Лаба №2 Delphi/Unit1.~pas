unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, XPMan, Math, ExtCtrls;

type
  TForm1 = class(TForm)
    Memo1: TMemo;
    Edit1: TEdit;
    Button1: TButton;
    Button2: TButton;
    Button3: TButton;
    Button4: TButton;
    Button5: TButton;
    Button6: TButton;
    Button7: TButton;
    Label1: TLabel;
    ComboBox1: TComboBox;
    Label2: TLabel;
    LabeledEdit1: TLabeledEdit;
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure Button4Click(Sender: TObject);
    procedure Button5Click(Sender: TObject);
    procedure Button7Click(Sender: TObject);
    procedure Button6Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  p: pointer;

implementation

{$R *.dfm}

procedure TForm1.Button1Click(Sender: TObject);
VAR
// SysInf:TSystemInfo;
 SysInf:SYSTEM_INFO;
begin
  GetSystemInfo(SysInf);
  Memo1.Clear;
  memo1.Lines.Add('Размер страницы: '+IntToStr(SysInf.dwPageSize)+' байт');
  memo1.Lines.Add('Процессор: '+IntToStr(SysInf.wProcessorArchitecture));
  memo1.Lines.Add('Зарезервировано: '+IntToStr(SysInf.wReserved));
  memo1.Lines.Add('Количество процессоров: '+IntToStr(SysInf.dwNumberOfProcessors));
  memo1.Lines.Add('Маска активного процессора: '+IntToStr(SysInf.dwActiveProcessorMask));
  memo1.Lines.Add('Тип процессора: '+IntToStr(SysInf.dwProcessorType));
  memo1.Lines.Add('Гранулярность выделения ресурсов: '+IntToStr(SysInf.dwAllocationGranularity));
  memo1.Lines.Add('Уровень процессора: '+IntToStr(SysInf.wProcessorLevel));
  memo1.Lines.Add('Ревизия процессора: '+IntToStr(SysInf.wProcessorRevision));
end;


procedure TForm1.Button2Click(Sender: TObject);
VAR  //ms:MEMORYSTATUS;
     ms:TMEMORYSTATUS;
begin
  ms.dwLength:=sizeof(MEMORYSTATUS);
  GlobalMemoryStatus(ms);
  Memo1.Clear;
  Memo1.Lines.Add('Загружено памяти: '+IntToStr(ms.dwMemoryLoad)+' байт');
  Memo1.Lines.Add('Всего физическая память: '+IntToStr(ms.dwTotalPhys)+' байт');
  Memo1.Lines.Add('Доступная физическая память: '+IntToStr(ms.dwAvailPhys)+' байт');
  Memo1.Lines.Add('Общий размер страничного файла: '+IntToStr(ms.dwTotalPageFile)+' байт');
  Memo1.Lines.Add('Доступный размер страничного файла: '+IntToStr(ms.dwAvailPageFile)+' байт');
  Memo1.Lines.Add('Общий размер виртуальной памяти: '+IntToStr(ms.dwTotalVirtual)+' байт');
  Memo1.Lines.Add('Доступный размер виртуальной памяти: '+IntToStr(ms.dwAvailVirtual)+' байт');
end;


procedure TForm1.Button3Click(Sender: TObject);
VAR //mbi:MEMORY_BASIC_INFORMATION;
    mbi:TMemoryBasicInformation;
    dwRez:DWORD;
begin
  if Edit1.GetTextLen<=0
  then ShowMessage('Введите виртуальный адрес')
  else
  begin
    dwRez:=VirtualQuery(pointer(StrToInt(Edit1.Text)),mbi,sizeof(MEMORY_BASIC_INFORMATION));
    Memo1.Clear;
    Memo1.Lines.Add('Базовый адрес: '+IntToStr(integer(mbi.BaseAddress)));
    Memo1.Lines.Add('Адрес размещения: '+IntToStr(integer(mbi.BaseAddress)));
    case mbi.AllocationProtect of
      0:            Memo1.Lines.Add('ВАП зарезервировано');
      PAGE_NOACCESS:Memo1.Lines.Add('Атрибут защиты ВАП: PAGE_NOACCESS');
      PAGE_READONLY:Memo1.Lines.Add('Атрибут защиты ВАП: PAGE_READONLY');
      PAGE_READWRITE:Memo1.Lines.Add('Атрибут защиты ВАП: PAGE_READWRITE');
      PAGE_EXECUTE:Memo1.Lines.Add('Атрибут защиты ВАП: PAGE_EXECUTE: ');
      PAGE_EXECUTE_READ:Memo1.Lines.Add('Атрибут защиты ВАП: PAGE_EXECUTE_READ');
      PAGE_EXECUTE_READWRITE:Memo1.Lines.Add('Атрибут защиты ВАП: PAGE_EXECUTE_READWRITE');
      PAGE_WRITECOPY:Memo1.Lines.Add('Атрибут защиты ВАП: PAGE_WRITECOPY');
      PAGE_EXECUTE_WRITECOPY:Memo1.Lines.Add('Атрибут защиты ВАП: PAGE_EXECUTE_WRITECOPY');
    end;
    Memo1.Lines.Add('Размер региона: '+IntToStr(mbi.RegionSize)+' байт');
    case mbi.State of
      MEM_COMMIT: Memo1.Lines.Add('Состояние ВАП: MEM_COMMIT');
      MEM_RESERVE: Memo1.Lines.Add('Состояние ВАП: MEM_RESERVE');
      MEM_FREE: Memo1.Lines.Add('Состояние ВАП: MEM_FREE');
    end;
    case mbi.Protect of
      0:            Memo1.Lines.Add('зарезервировано');
      PAGE_NOACCESS:Memo1.Lines.Add('Атрибут защиты физ.памяти: PAGE_NOACCESS');
      PAGE_READONLY:Memo1.Lines.Add('Атрибут защиты ВАП: PAGE_READONLY');
      PAGE_READWRITE:Memo1.Lines.Add('Атрибут защиты ВАП: PAGE_READWRITE');
      PAGE_EXECUTE:Memo1.Lines.Add('Атрибут защиты ВАП: PAGE_EXECUTE');
      PAGE_EXECUTE_READ:Memo1.Lines.Add('Атрибут защиты ВАП: PAGE_EXECUTE_READ');
      PAGE_EXECUTE_READWRITE:Memo1.Lines.Add('Атрибут защиты ВАП: PAGE_EXECUTE_READWRITE');
      PAGE_WRITECOPY:Memo1.Lines.Add('Атрибут защиты ВАП: PAGE_WRITECOPY');
      PAGE_EXECUTE_WRITECOPY:Memo1.Lines.Add('Атрибут защиты ВАП: PAGE_EXECUTE_WRITECOPY');
    end;
  end;
end;


procedure TForm1.Button4Click(Sender: TObject);
VAR   ms:MEMORYSTATUS;
begin
  Memo1.Clear;
  if Edit1.GetTextLen=0 then
  begin
    p:=VirtualAlloc(nil,StrToInt(LabeledEdit1.Text),MEM_COMMIT,PAGE_READWRITE);
    Edit1.Text := IntToStr(integer(p));
  end
  else
    p:=VirtualAlloc(pointer(StrToInt64(Edit1.Text)),StrToInt(LabeledEdit1.Text),MEM_COMMIT,PAGE_READWRITE);
  if p <> nil then
    Memo1.Lines.Add('Память выделена успешно!')
  else
    Memo1.Lines.Add('Произошла ошибка! Память не выделена.');
  ms.dwLength:=sizeof(MEMORYSTATUS);
  GlobalMemoryStatus(ms);
  Memo1.Lines.Add('Загружено памяти: '+IntToStr(ms.dwMemoryLoad)+' байт');
  Memo1.Lines.Add('Всего физическая память: '+IntToStr(ms.dwTotalPhys)+' байт');
  Memo1.Lines.Add('Доступная физическая память: '+IntToStr(ms.dwAvailPhys)+' байт');
  Memo1.Lines.Add('Общий размер страничного файла: '+IntToStr(ms.dwTotalPageFile)+' байт');
  Memo1.Lines.Add('Доступный размер страничного файла: '+IntToStr(ms.dwAvailPageFile)+' байт');
  Memo1.Lines.Add('Общий размер виртуальной памяти: '+IntToStr(ms.dwTotalVirtual)+' байт');
  Memo1.Lines.Add('Доступный размер виртуальной памяти: '+IntToStr(ms.dwAvailVirtual)+' байт');
end;


procedure TForm1.Button5Click(Sender: TObject);
VAR
    ms:MEMORYSTATUS;
begin
  Memo1.Clear;
  if VirtualFree(p,StrToInt(LabeledEdit1.Text),MEM_DECOMMIT) and VirtualFree(p,0,MEM_RELEASE) then
    Memo1.Lines.Add('Память освобождена успешно!')
  else
    Memo1.Lines.Add('Произошла ошибка! Память не освобождена.');
  ms.dwLength:=sizeof(MEMORYSTATUS);
  GlobalMemoryStatus(ms);
  Memo1.Lines.Add('Загружено памяти: '+IntToStr(ms.dwMemoryLoad)+' байт');
  Memo1.Lines.Add('Всего физическая память: '+IntToStr(ms.dwTotalPhys)+' байт');
  Memo1.Lines.Add('Доступная физическая память: '+IntToStr(ms.dwAvailPhys)+' байт');
  Memo1.Lines.Add('Общий размер страничного файла: '+IntToStr(ms.dwTotalPageFile)+' байт');
  Memo1.Lines.Add('Доступный размер страничного файла: '+IntToStr(ms.dwAvailPageFile)+' байт');
  Memo1.Lines.Add('Общий размер виртуальной памяти: '+IntToStr(ms.dwTotalVirtual)+' байт');
  Memo1.Lines.Add('Доступный размер виртуальной памяти: '+IntToStr(ms.dwAvailVirtual)+' байт');
end;


procedure TForm1.Button7Click(Sender: TObject);
begin
  Form1.Close;
end;

function ArrayFind(a: array of dword; value: dword): integer;
var i: integer;
begin
  for i:=LOW(a) to HIGH(a) do
    if a[i] = value then
      Result := i;
end;

procedure TForm1.Button6Click(Sender: TObject);
var
  OldProtect,NewProtect: DWORD;
  a: array[0..7] of DWORD;
  success: boolean;
begin
  a[0] := PAGE_NOACCESS;
  a[1] := PAGE_READONLY;
  a[2] := PAGE_READWRITE;
  a[3] := PAGE_EXECUTE;
  a[4] := PAGE_EXECUTE_READ;
  a[5] := PAGE_EXECUTE_READWRITE;
  a[6] := PAGE_WRITECOPY;
  a[7] := PAGE_EXECUTE_WRITECOPY;
  NewProtect := a[ComboBox1.ItemIndex];
  success := VirtualProtect(pointer(StrToInt64(Edit1.Text)),StrToInt(LabeledEdit1.Text),NewProtect,OldProtect);
  Memo1.Clear;
  if success then
    Memo1.Lines.Add('Атрибут успешно изменен на: ' + ComboBox1.Items[ArrayFind(a,NewProtect)])
  else
    Memo1.Lines.Add('Не удалось изменить атрибут');
  Memo1.Lines.Add('Старый артибут защиты: ' + ComboBox1.Items[ArrayFind(a,OldProtect)]);
  //ShowMessage(ComboBox1.Items[ArrayFind(a,2)]);
end;

end.


