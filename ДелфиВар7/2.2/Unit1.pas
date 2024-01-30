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
    Label1: TLabel;
    Edit1: TEdit;
    memo1: TMemo;
    Label2: TLabel;
    Label3: TLabel;
    Edit2: TEdit;
    ComboBox1: TComboBox;
    Memo2: TMemo;
    Button8: TButton;
    procedure Button1Click(Sender: TObject);
    procedure FormActivate(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure Button4Click(Sender: TObject);
    procedure Button5Click(Sender: TObject);
    procedure Button7Click(Sender: TObject);
    procedure Button6Click(Sender: TObject);
    procedure Button8Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  p:pointer;
implementation

{$R *.dfm}

procedure TForm1.Button1Click(Sender: TObject);
 VAR
 //SysInf:TSystemInfo;
 SysInf:SYSTEM_INFO;
begin
  GetSystemInfo(SysInf);
  Memo1.Clear;
  memo1.Lines.Add('������ �������� '+IntToStr(SysInf.dwPageSize)+' ����');
  memo1.Lines.Add('��������� '+IntToStr(SysInf.wProcessorArchitecture));
  memo1.Lines.Add('��������������� '+IntToStr(SysInf.wReserved));
  memo1.Lines.Add('���������� ����������� '+IntToStr(SysInf.dwNumberOfProcessors));
  memo1.Lines.Add('����� ��������� ���������� '+IntToStr(SysInf.dwActiveProcessorMask));
  memo1.Lines.Add('��� ���������� '+IntToStr(SysInf.dwProcessorType));
  memo1.Lines.Add('������������� ��������� �������� '+IntToStr(SysInf.dwAllocationGranularity));
  memo1.Lines.Add('����� ������ ���������� '+IntToStr(SysInf.wProcessorLevel));
  memo1.Lines.Add('����� ������ ������ ���������� '+IntToStr(SysInf.wProcessorRevision));
end;

procedure TForm1.FormActivate(Sender: TObject);
begin
   Memo1.Clear;
   Memo2.Clear;
end;

procedure TForm1.Button2Click(Sender: TObject);
  VAR  //ms:MEMORYSTATUS;
     ms:TMEMORYSTATUS;
begin
    ms.dwLength:=sizeof(MEMORYSTATUS);
  GlobalMemoryStatus(ms);
  Memo1.Clear;
  Memo1.Lines.Add('��������� ������ '+IntToStr(ms.dwMemoryLoad)+' ����');
  Memo1.Lines.Add('����� ���������� ������ '+IntToStr(ms.dwTotalPhys)+' ����');
  Memo1.Lines.Add('��������� ���������� ������ '+IntToStr(ms.dwAvailPhys)+' ����');
  Memo1.Lines.Add('����� ������ ����������� ����� '+IntToStr(ms.dwTotalPageFile)+' ����');
  Memo1.Lines.Add('��������� ������ ����������� ����� '+IntToStr(ms.dwAvailPageFile)+' ����');
  Memo1.Lines.Add('����� ������ ����������� ������ '+IntToStr(ms.dwTotalVirtual)+' ����');
  Memo1.Lines.Add('��������� ������ ����������� ������ '+IntToStr(ms.dwAvailVirtual)+' ����');
end;

procedure TForm1.Button3Click(Sender: TObject);
   VAR //mbi:MEMORY_BASIC_INFORMATION;
    mbi:TMemoryBasicInformation;
    dwRez:DWORD;
begin
  if Edit1.GetTextLen<=0
  then ShowMessage('������� ����������� �����')
  else
  begin
  dwRez:=VirtualQuery(pointer(StrToInt(Edit1.Text)),mbi,sizeof(MEMORY_BASIC_INFORMATION));
    Memo1.Clear;
    Memo1.Lines.Add('������� ����� '+IntToStr(integer(mbi.BaseAddress)));
    Memo1.Lines.Add('����� ����������'+IntToStr(integer(mbi.BaseAddress)));
    case mbi.AllocationProtect of
      0:            Memo1.Lines.Add('��� ���������������');
      PAGE_NOACCESS:Memo1.Lines.Add('������� ������ ��� PAGE_NOACCESS');
      PAGE_READONLY:Memo1.Lines.Add('������� ������ ��� PAGE_READONLY');
      PAGE_READWRITE:Memo1.Lines.Add('������� ������ ��� PAGE_READWRITE');
      PAGE_EXECUTE:Memo1.Lines.Add('������� ������ ��� PAGE_EXECUTE');
      PAGE_EXECUTE_READ:Memo1.Lines.Add('������� ������ ��� PAGE_EXECUTE_READ');
      PAGE_EXECUTE_READWRITE:Memo1.Lines.Add('������� ������ ��� PAGE_EXECUTE_READWRITE');
      PAGE_WRITECOPY:Memo1.Lines.Add('������� ������ ��� PAGE_WRITECOPY');
      PAGE_EXECUTE_WRITECOPY:Memo1.Lines.Add('������� ������ ��� PAGE_EXECUTE_WRITECOPY');
    end;
    Memo1.Lines.Add('������ ������� '+IntToStr(mbi.RegionSize)+' ����');
    case mbi.State of
      MEM_COMMIT: Memo1.Lines.Add('��������� ��� MEM_COMMIT');
      MEM_RESERVE: Memo1.Lines.Add('��������� ��� MEM_RESERVE');
      MEM_FREE: Memo1.Lines.Add('��������� ��� MEM_FREE');
    end;
    case mbi.Protect of
      0:            Memo1.Lines.Add('���������������');
      PAGE_NOACCESS:Memo1.Lines.Add('������� ������ ���.������ PAGE_NOACCESS');
      PAGE_READONLY:Memo1.Lines.Add('������� ������ ��� PAGE_READONLY');
      PAGE_READWRITE:Memo1.Lines.Add('������� ������ ��� PAGE_READWRITE');
      PAGE_EXECUTE:Memo1.Lines.Add('������� ������ ��� PAGE_EXECUTE');
      PAGE_EXECUTE_READ:Memo1.Lines.Add('������� ������ ��� PAGE_EXECUTE_READ');
      PAGE_EXECUTE_READWRITE:Memo1.Lines.Add('������� ������ ��� PAGE_EXECUTE_READWRITE');
      PAGE_WRITECOPY:Memo1.Lines.Add('������� ������ ��� PAGE_WRITECOPY');
      PAGE_EXECUTE_WRITECOPY:Memo1.Lines.Add('������� ������ ��� PAGE_EXECUTE_WRITECOPY');
    end;
  end;
end;

procedure TForm1.Button4Click(Sender: TObject);
VAR   ms:MEMORYSTATUS;
begin
  If (Edit1.GetTextLen=0) and (Edit2.GetTextLen = 0) then
  begin
     p:=VirtualAlloc(nil,4096,MEM_COMMIT,PAGE_READWRITE)
  end
  else
  begin
    if Edit1.GetTextLen = 0 then
    begin
       p:=VirtualAlloc(nil,StrToInt(Edit2.Text),MEM_COMMIT,PAGE_READWRITE);
    end
    else
    begin
       if Edit2.GetTextLen = 0 then
       begin
           p:=VirtualAlloc(pointer(StrToInt64(Edit1.Text)),4096,MEM_COMMIT,PAGE_READWRITE);
       end
       else
       begin
          p:=VirtualAlloc(pointer(StrToInt64(Edit1.Text)),StrToInt(Edit2.Text),MEM_COMMIT,PAGE_READWRITE);
       end;
    end;
  end;
  Edit1.Text:= IntToStr(Integer(p));
  Memo1.Clear;
  ms.dwLength:=sizeof(MEMORYSTATUS);
  GlobalMemoryStatus(ms);
  Memo1.Clear;
  Memo1.Lines.Add('��������� ������ '+IntToStr(ms.dwMemoryLoad)+' ����');
  Memo1.Lines.Add('����� ���������� ������ '+IntToStr(ms.dwTotalPhys)+' ����');
  Memo1.Lines.Add('��������� ���������� ������ '+IntToStr(ms.dwAvailPhys)+' ����');
  Memo1.Lines.Add('����� ������ ����������� ����� '+IntToStr(ms.dwTotalPageFile)+' ����');
  Memo1.Lines.Add('��������� ������ ����������� ����� '+IntToStr(ms.dwAvailPageFile)+' ����');
  Memo1.Lines.Add('����� ������ ����������� ������ '+IntToStr(ms.dwTotalVirtual)+' ����');
  Memo1.Lines.Add('��������� ������ ����������� ������ '+IntToStr(ms.dwAvailVirtual)+' ����');
end;

procedure TForm1.Button5Click(Sender: TObject);
VAR
    ms:MEMORYSTATUS;
begin
  if Edit2.GetTextLen = 0 then
  begin
    VirtualFree(p,4096,MEM_DECOMMIT);
    VirtualFree(p,4096,MEM_RELEASE);
  end
  else
  begin
    VirtualFree(p,StrToInt(Edit2.Text),MEM_DECOMMIT);
    VirtualFree(p,StrToInt(Edit2.Text),MEM_RELEASE);
  end;
  Memo1.Clear;
  ms.dwLength:=sizeof(MEMORYSTATUS);
  GlobalMemoryStatus(ms);
  Memo1.Clear;
  Memo1.Lines.Add('��������� ������ '+IntToStr(ms.dwMemoryLoad)+' ����');
  Memo1.Lines.Add('����� ���������� ������ '+IntToStr(ms.dwTotalPhys)+' ����');
  Memo1.Lines.Add('��������� ���������� ������ '+IntToStr(ms.dwAvailPhys)+' ����');
  Memo1.Lines.Add('����� ������ ����������� ����� '+IntToStr(ms.dwTotalPageFile)+' ����');
  Memo1.Lines.Add('��������� ������ ����������� ����� '+IntToStr(ms.dwAvailPageFile)+' ����');
  Memo1.Lines.Add('����� ������ ����������� ������ '+IntToStr(ms.dwTotalVirtual)+' ����');
  Memo1.Lines.Add('��������� ������ ����������� ������ '+IntToStr(ms.dwAvailVirtual)+' ����');
end;


procedure TForm1.Button7Click(Sender: TObject);
begin
    Form1.Close;
end;

procedure TForm1.Button6Click(Sender: TObject);
  var
  lpflOldProtect: DWORD;
  dwSize: DWORD;
  success: boolean;
begin
  if ComboBox1.Text = '' then
  ShowMessage('�������� ������� ������ ��������')
  else
  begin
    if Edit2.GetTextLen = 0 then
    begin
    dwSize:= 4096;
    end
    else
    begin
    dwSize:= StrToInt(Edit2.Text);
    end;
    case ComboBox1.ItemIndex of
    0: success:=VirtualProtect(pointer(StrToInt64(Edit1.Text)),dwSize,PAGE_NOACCESS,lpflOldProtect);
    1: success:=VirtualProtect(pointer(StrToInt64(Edit1.Text)),dwSize,PAGE_READONLY,lpflOldProtect);
    2: success:=VirtualProtect(pointer(StrToInt64(Edit1.Text)),dwSize,PAGE_READWRITE,lpflOldProtect);
    3: success:=VirtualProtect(pointer(StrToInt64(Edit1.Text)),dwSize,PAGE_EXECUTE,lpflOldProtect);
    4: success:=VirtualProtect(pointer(StrToInt64(Edit1.Text)),dwSize,PAGE_EXECUTE_READ,lpflOldProtect);
    5: success:=VirtualProtect(pointer(StrToInt64(Edit1.Text)),dwSize,PAGE_EXECUTE_READWRITE,lpflOldProtect);
    6: success:=VirtualProtect(pointer(StrToInt64(Edit1.Text)),dwSize,PAGE_WRITECOPY,lpflOldProtect);
    7: success:=VirtualProtect(pointer(StrToInt64(Edit1.Text)),dwSize,PAGE_EXECUTE_WRITECOPY,lpflOldProtect);
    end;
    Memo1.Clear;
    if success then
    begin
      Memo1.Lines.Add('������� ������� ������� ��: ' + ComboBox1.Text);
      case lpflOldProtect of
      PAGE_NOACCESS:Memo1.Lines.Add('������ �������: PAGE_NOACCESS');
      PAGE_READONLY:Memo1.Lines.Add('������ �������: PAGE_READONLY');
      PAGE_READWRITE:Memo1.Lines.Add('������ �������: PAGE_READWRITE');
      PAGE_EXECUTE:Memo1.Lines.Add('������ �������: PAGE_EXECUTE');
      PAGE_EXECUTE_READ:Memo1.Lines.Add('������ �������: PAGE_EXECUTE_READ');
      PAGE_EXECUTE_READWRITE:Memo1.Lines.Add('������ �������: PAGE_EXECUTE_READWRITE');
      PAGE_WRITECOPY:Memo1.Lines.Add('������ �������: PAGE_WRITECOPY');
      PAGE_EXECUTE_WRITECOPY:Memo1.Lines.Add('������ �������: PAGE_EXECUTE_WRITECOPY');
      end;
    end
    else
    begin
      Memo1.Lines.Add('�� ������� �������� �������');
    end;
  end;
end;


procedure TForm1.Button8Click(Sender: TObject);
  var
  mbi:TMemoryBasicInformation;
  dwRez, i:DWORD;
begin
  memo2.Clear;
  i:=00000000;
  while i < 11111111 do
  begin
     dwRez:=VirtualQuery(pointer(i),mbi,sizeof(MEMORY_BASIC_INFORMATION));
     if mbi.State = MEM_FREE then Memo2.Lines.Add(IntToStr(i));
     Inc(i,mbi.RegionSize);
  end;
end;

end.
