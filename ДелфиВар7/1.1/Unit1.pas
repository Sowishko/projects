unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Registry;
type
  TForm1 = class(TForm)
    GroupBox1: TGroupBox;
    GroupBox2: TGroupBox;
    GroupBox3: TGroupBox;
    Edit1: TEdit;
    Button1: TButton;
    Label1: TLabel;
    Label2: TLabel;
    Edit2: TEdit;
    Label3: TLabel;
    Edit3: TEdit;
    Label4: TLabel;
    Edit4: TEdit;
    Edit5: TEdit;
    Button2: TButton;
    Label5: TLabel;
    Edit6: TEdit;
    Label6: TLabel;
    Edit7: TEdit;
    Label7: TLabel;
    Edit8: TEdit;
    Label8: TLabel;
    Edit9: TEdit;
    Label9: TLabel;
    Label10: TLabel;
    Edit10: TEdit;
    Edit11: TEdit;
    Label11: TLabel;
    Edit12: TEdit;
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure FormCreate(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

implementation

{$R *.dfm}


procedure TForm1.Button1Click(Sender: TObject);
VAR
  SerialNum:DWORD;
  a,b:DWORD;
  Buffer,disk :Array[0..255]of char;
begin
  StrPCopy(@disk,Edit1.text);
  if GetVolumeInformation(@disk,Buffer,sizeof(Buffer),@SerialNum,a,b,nil,0) then
  begin
    Edit2.Text:=IntToStr(SerialNum);
    Edit3.Text:=Buffer;
    Edit4.Text:=IntToStr(a);
  end;
end;


procedure TForm1.FormCreate(Sender: TObject);
VAR
  v:TOSVERSIONINFO;
  reg:TRegistry;
  a:Array[0..255] of Char;
begin
  Edit1.Text:='C:\';
  // ���������� �� ������������ �������
  v.dwOSVersionInfoSize:=Sizeof(OSVERSIONINFO);
  GetVersionEx(v);
  Edit6.Text:=IntToStr(v.dwMajorVersion)+'.'+IntToStr(v.dwMinorVersion);
  Edit7.Text:=IntToStr(v.dwBuildNumber);
  Edit8.Text:=v.szCSDVersion;
  case v.dwPlatformId of
    VER_PLATFORM_WIN32s:        Edit9.Text:='Win32s on Windows 3.1.';
    VER_PLATFORM_WIN32_WINDOWS:	Edit9.Text:='Win32 on Windows 95.';
    VER_PLATFORM_WIN32_NT:  	  Edit9.Text:='Win32 on Windows NT.';
  end;
  // �����������, �� ������ �������� ����������������  Windows
  reg:=TRegistry.Create;
  reg.RootKey:=HKEY_LOCAL_MACHINE;
  reg.OpenKey('Software\Microsoft\Windows\CurrentVersion\Setup',false);
  Edit10.Text:=reg.ReadString('SourcePath');
  reg.CloseKey;
  reg.Free;
  // ��������� ��������
  GetSystemDirectory(@a,Sizeof(a));
  Edit11.Text:=a;
  GetWindowsDirectory(@a,Sizeof(a));
  Edit12.Text:=a;
       end;
       function GetCPUSpeed: Double;
const
  DelayTime = 500;
var
  TimerHi: DWORD;
  TimerLo: DWORD;
  PriorityClass: Integer;
  Priority: Integer;
 begin
  PriorityClass := GetPriorityClass(GetCurrentProcess);
  Priority := GetThreadPriority(GetCurrentThread);
  SetPriorityClass(GetCurrentProcess, REALTIME_PRIORITY_CLASS);
  SetThreadPriority(GetCurrentThread, THREAD_PRIORITY_TIME_CRITICAL);
  Sleep(10);
  asm
   DW  310Fh        // rdtsc
   MOV TimerLo, EAX
   MOV TimerHi, EDX
  end;
  Sleep(DelayTime);
  asm
    DW  310Fh        // rdtsc
    SUB EAX, TimerLo
    SBB EDX, TimerHi
    MOV TimerLo, EAX
    MOV TimerHi, EDX
  end;
  SetThreadPriority(GetCurrentThread, Priority);
  SetPriorityClass(GetCurrentProcess, PriorityClass);
  Result:=TimerLo/(1000.0 * DelayTime);
end;


   procedure TForm1.Button2Click(Sender: TObject);
begin
// ��������� �������� ������� ����������
  Edit5.Text:=Format('CPU Speed: %f MHz',[GetCpuSpeed]);
end;


end.
