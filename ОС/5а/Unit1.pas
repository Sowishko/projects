unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ShellAPI;

type
  TForm1 = class(TForm)
    Button1: TButton;
    ComboBox1: TComboBox;
    Button2: TButton;
    Label1: TLabel;
    Edit1: TEdit;
    Button3: TButton;
    Button4: TButton;
    procedure Button1Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button4Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  StartInfo: TStartUpInfo;
  ProcInfo: TProcessInformation;

implementation

{$R *.dfm}

function Priority(P: DWORD): string;

begin

  case P of

    REALTIME_PRIORITY_CLASS: Result := 'Real time';

    HIGH_PRIORITY_CLASS: Result := 'High';

    NORMAL_PRIORITY_CLASS: Result := 'Normal';

    IDLE_PRIORITY_CLASS: Result := 'Idle';

  end;

end;

procedure TForm1.Button1Click(Sender: TObject);

var
  POperation: array[0..50] of Char;

  PFilename: array[0..254] of Char;

  P: DWORD;

begin
  FillChar(StartInfo, Sizeof(StartInfo), #0);
  StartInfo.cb := Sizeof(StartInfo);

  POperation := 'open' + #0;

  PFilename := 'C:\Windows\system32\Calc.exe' + #0;

  {ShellExecute(Handle, POperation, PFilename, nil, nil, SW_RESTORE); }

  CreateProcess(nil, PFilename, nil, nil, False, NORMAL_PRIORITY_CLASS, nil, nil, StartInfo, ProcInfo);

  P := GetPriorityClass(GetCurrentProcess());

  Edit1.Text := Priority(P);

end;

procedure TForm1.Button3Click(Sender: TObject);
begin
  Form1.Close;
end;

procedure TForm1.Button2Click(Sender: TObject);

var
  P: DWORD;

begin

  if ComboBox1.Text = 'Idle' then

    P := IDLE_PRIORITY_CLASS;

  if ComboBox1.Text = 'Normal' then

    P := NORMAL_PRIORITY_CLASS;

  if ComboBox1.Text = 'High' then

    P := HIGH_PRIORITY_CLASS;

  if ComboBox1.Text = 'Real time' then

    P := REALTIME_PRIORITY_CLASS;

  SetPriorityClass(GetCurrentProcess(), P);

  P := GetPriorityClass(GetCurrentProcess());

  Edit1.Text := Priority(P);

end;

procedure TForm1.Button4Click(Sender: TObject);
var
  jjj: UINT;
begin
  TerminateProcess(ProcInfo.hProcess, jjj);
end;

end.

