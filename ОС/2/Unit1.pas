unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls;

type
  TForm1 = class(TForm)
    Button1: TButton;
    Button2: TButton;
    Button3: TButton;
    Button4: TButton;
    Button5: TButton;
    Button6: TButton;
    Button7: TButton;
    Memo1: TMemo;
    Label1: TLabel;
    Edit1: TEdit;
    Edit2: TEdit;
    Label2: TLabel;
    Edit3: TEdit;
    Label3: TLabel;
    Memo2: TMemo;
    Label4: TLabel;
    procedure FormActivate(Sender: TObject);
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

procedure TForm1.FormActivate(Sender: TObject);
begin
  Memo1.Clear;
  Memo2.Clear;
end;

procedure TForm1.Button1Click(Sender: TObject);
var
  // SysInf:TSystemInfo;
  SysInf: SYSTEM_INFO;
begin
  GetSystemInfo(SysInf);
  Memo1.Clear;
  memo1.Lines.Add('������ �������� ' + IntToStr(SysInf.dwPageSize) + ' ����');
  memo1.Lines.Add('��������� ' + IntToStr(SysInf.wProcessorArchitecture));
  memo1.Lines.Add('��������������� ' + IntToStr(SysInf.wReserved));
  memo1.Lines.Add('���������� ����������� ' +
    IntToStr(SysInf.dwNumberOfProcessors));
  memo1.Lines.Add('����� ��������� ���������� ' +
    IntToStr(SysInf.dwActiveProcessorMask));
  memo1.Lines.Add('��� ���������� ' + IntToStr(SysInf.dwProcessorType));
  memo1.Lines.Add('������������� ��������� �������� ' +
    IntToStr(SysInf.dwAllocationGranularity));
  memo1.Lines.Add(' ' + IntToStr(SysInf.wProcessorLevel));
  memo1.Lines.Add(' ' + IntToStr(SysInf.wProcessorRevision));
end;

procedure TForm1.Button2Click(Sender: TObject);
var //ms:MEMORYSTATUS;
  ms: TMEMORYSTATUS;
begin
  ms.dwLength := sizeof(MEMORYSTATUS);
  GlobalMemoryStatus(ms);
  Memo1.Clear;
  Memo1.Lines.Add('��������� ������ ' + IntToStr(ms.dwMemoryLoad) + ' ����');
  Memo1.Lines.Add('����� ���������� ������ ' + IntToStr(ms.dwTotalPhys) +
    ' ����');
  Memo1.Lines.Add('��������� ���������� ������ ' + IntToStr(ms.dwAvailPhys) +
    ' ����');
  Memo1.Lines.Add('����� ������ ����������� ����� ' +
    IntToStr(ms.dwTotalPageFile) + ' ����');
  Memo1.Lines.Add('��������� ������ ����������� ����� ' +
    IntToStr(ms.dwAvailPageFile) + ' ����');
  Memo1.Lines.Add('����� ������ ����������� ������ ' +
    IntToStr(ms.dwTotalVirtual) + ' ����');
  Memo1.Lines.Add('��������� ������ ����������� ������ ' +
    IntToStr(ms.dwAvailVirtual) + ' ����');
end;

procedure TForm1.Button3Click(Sender: TObject);
var //mbi:MEMORY_BASIC_INFORMATION;
  mbi: TMemoryBasicInformation;
  dwRez: DWORD;
begin
  if Edit1.GetTextLen = 0 then
    dwRez := VirtualQuery(p, mbi, sizeof(MEMORY_BASIC_INFORMATION))
  else
    dwRez := VirtualQuery(pointer(StrToInt(Edit1.Text)), mbi,
      sizeof(MEMORY_BASIC_INFORMATION));
  Memo1.Clear;
  Memo1.Lines.Add('������� ����� ' + IntToStr(integer(mbi.BaseAddress)));
  Memo1.Lines.Add('����� ����������' + IntToStr(integer(mbi.BaseAddress)));
  case mbi.AllocationProtect of
    0: Memo1.Lines.Add('��� ���������������');
    PAGE_NOACCESS: Memo1.Lines.Add('������� ������ ��� PAGE_NOACCESS');
    PAGE_READONLY: Memo1.Lines.Add('������� ������ ��� PAGE_READONLY');
    PAGE_READWRITE: Memo1.Lines.Add('������� ������ ��� PAGE_READWRITE');
    PAGE_EXECUTE: Memo1.Lines.Add('������� ������ ��� PAGE_EXECUTE');
    PAGE_EXECUTE_READ: Memo1.Lines.Add('������� ������ ��� PAGE_EXECUTE_READ');
    PAGE_EXECUTE_READWRITE:
      Memo1.Lines.Add('������� ������ ��� PAGE_EXECUTE_READWRITE');
    PAGE_WRITECOPY: Memo1.Lines.Add('������� ������ ��� PAGE_WRITECOPY');
    PAGE_EXECUTE_WRITECOPY:
      Memo1.Lines.Add('������� ������ ��� PAGE_EXECUTE_WRITECOPY');
  end;
  Memo1.Lines.Add('������ ������� ' + IntToStr(mbi.RegionSize) + ' ����');
  case mbi.State of
    MEM_COMMIT: Memo1.Lines.Add('��������� ��� MEM_COMMIT');
    MEM_RESERVE: Memo1.Lines.Add('��������� ��� MEM_RESERVE');
    MEM_FREE: Memo1.Lines.Add('��������� ��� MEM_FREE');
  end;
  case mbi.Protect of
    0: Memo1.Lines.Add('���������������');
    PAGE_NOACCESS: Memo1.Lines.Add('������� ������ ���.������ PAGE_NOACCESS');
    PAGE_READONLY: Memo1.Lines.Add('������� ������ ��� PAGE_READONLY');
    PAGE_READWRITE: Memo1.Lines.Add('������� ������ ��� PAGE_READWRITE');
    PAGE_EXECUTE: Memo1.Lines.Add('������� ������ ��� PAGE_EXECUTE');
    PAGE_EXECUTE_READ: Memo1.Lines.Add('������� ������ ��� PAGE_EXECUTE_READ');
    PAGE_EXECUTE_READWRITE:
      Memo1.Lines.Add('������� ������ ��� PAGE_EXECUTE_READWRITE');
    PAGE_WRITECOPY: Memo1.Lines.Add('������� ������ ��� PAGE_WRITECOPY');
    PAGE_EXECUTE_WRITECOPY:
      Memo1.Lines.Add('������� ������ ��� PAGE_EXECUTE_WRITECOPY');
  end;
  if mbi.State = MEM_FREE then
    Memo2.Lines.Add('������� �����: ' + IntToStr(integer(mbi.BaseAddress)))
end;

procedure TForm1.Button4Click(Sender: TObject);
var
  ms: MEMORYSTATUS;
begin
  if Edit1.GetTextLen = 0 then
    if Edit3.GetTextLen = 0 then
      p := VirtualAlloc(nil, 4096, MEM_COMMIT, PAGE_READWRITE)
    else if Edit3.GetTextLen = 0 then
      p := VirtualAlloc(pointer(StrToInt64(Edit1.Text)), 4096, MEM_COMMIT,
        PAGE_READWRITE)
    else if Edit1.GetTextLen = 0 then
      p := VirtualAlloc(nil, integer(StrToInt64(Edit3.Text)), MEM_COMMIT,
        PAGE_READWRITE);
  Memo1.Clear;
  ms.dwLength := sizeof(MEMORYSTATUS);
  GlobalMemoryStatus(ms);
  Memo1.Clear;
  Memo1.Lines.Add('��������� ������ ' + IntToStr(ms.dwMemoryLoad) + ' ����');
  Memo1.Lines.Add('����� ���������� ������ ' + IntToStr(ms.dwTotalPhys) +
    ' ����');
  Memo1.Lines.Add('��������� ���������� ������ ' + IntToStr(ms.dwAvailPhys) +
    ' ����');
  Memo1.Lines.Add('����� ������ ����������� ����� ' +
    IntToStr(ms.dwTotalPageFile) + ' ����');
  Memo1.Lines.Add('��������� ������ ����������� ����� ' +
    IntToStr(ms.dwAvailPageFile) + ' ����');
  Memo1.Lines.Add('����� ������ ����������� ������ ' +
    IntToStr(ms.dwTotalVirtual) + ' ����');
  Memo1.Lines.Add('��������� ������ ����������� ������ ' +
    IntToStr(ms.dwAvailVirtual) + ' ����');
end;

procedure TForm1.Button5Click(Sender: TObject);
var
  ms: MEMORYSTATUS;
begin
  VirtualFree(p, 4096, MEM_DECOMMIT);
  VirtualFree(p, 4096, MEM_RELEASE);
  Memo1.Clear;
  ms.dwLength := sizeof(MEMORYSTATUS);
  GlobalMemoryStatus(ms);
  Memo1.Clear;
  Memo1.Lines.Add('��������� ������ ' + IntToStr(ms.dwMemoryLoad) + ' ����');
  Memo1.Lines.Add('����� ���������� ������ ' + IntToStr(ms.dwTotalPhys) +
    ' ����');
  Memo1.Lines.Add('��������� ���������� ������ ' + IntToStr(ms.dwAvailPhys) +
    ' ����');
  Memo1.Lines.Add('����� ������ ����������� ����� ' +
    IntToStr(ms.dwTotalPageFile) + ' ����');
  Memo1.Lines.Add('��������� ������ ����������� ����� ' +
    IntToStr(ms.dwAvailPageFile) + ' ����');
  Memo1.Lines.Add('����� ������ ����������� ������ ' +
    IntToStr(ms.dwTotalVirtual) + ' ����');
  Memo1.Lines.Add('��������� ������ ����������� ������ ' +
    IntToStr(ms.dwAvailVirtual) + ' ����');
end;

procedure TForm1.Button7Click(Sender: TObject);
begin
  Form1.Close;
end;

procedure TForm1.Button6Click(Sender: TObject);
var
  lpflOldProtect: DWORD;
begin
  if Edit2.Text = 'PAGE_NOACCESS' then
    VirtualProtect(pointer(StrToInt(Edit1.Text)), 4096, PAGE_NOACCESS,
      lpflOldProtect);
  if Edit2.Text = 'PAGE_READONLY' then
    VirtualProtect(pointer(StrToInt(Edit1.Text)), 4096, PAGE_READONLY,
      lpflOldProtect);
  if Edit2.Text = 'PAGE_READWRITE' then
    VirtualProtect(pointer(StrToInt(Edit1.Text)), 4096, PAGE_READWRITE,
      lpflOldProtect);
  if Edit2.Text = 'PAGE_EXECUTE' then
    VirtualProtect(pointer(StrToInt(Edit1.Text)), 4096, PAGE_EXECUTE,
      lpflOldProtect);
  if Edit2.Text = 'PAGE_EXECUTE_READ' then
    VirtualProtect(pointer(StrToInt(Edit1.Text)), 4096, PAGE_EXECUTE_READ,
      lpflOldProtect);
  if Edit2.Text = 'PAGE_EXECUTE_READWRITE' then
    VirtualProtect(pointer(StrToInt(Edit1.Text)), 4096, PAGE_EXECUTE_READWRITE,
      lpflOldProtect);
  if Edit2.Text = 'PAGE_WRITECOPY' then
    VirtualProtect(pointer(StrToInt(Edit1.Text)), 4096, PAGE_WRITECOPY,
      lpflOldProtect);
  if Edit2.Text = 'PAGE_EXECUTE_WRITECOPY' then
    VirtualProtect(pointer(StrToInt(Edit1.Text)), 4096, PAGE_EXECUTE_WRITECOPY,
      lpflOldProtect);
end;

end.

