unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ShellAPI;

type
  TForm1 = class(TForm)
    Button1: TButton;
    Button2: TButton;
    Button3: TButton;
    OpenDialog1: TOpenDialog;
    Button4: TButton;
    Button5: TButton;
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure Button4Click(Sender: TObject);
    procedure Button5Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  
  StartInfo: TStartUpInfo;
  ProcInfo: TProcessInformation;
  ErrCode:Integer;
    PName:Array [0..79] of char;
  POperation:Array[0..50] of Char;
  PFilename:Array[0..254] of Char;

implementation

{$R *.dfm}

procedure TForm1.Button1Click(Sender: TObject);
 VAR ErrCode:Integer;
    PName:Array [0..79] of char;
begin
  If OpenDialog1.Execute then
  begin
    ErrCode:=WinExec(StrPCopy(PName,OpenDialog1.FileName),SW_RESTORE);
    PName:=PName;
    Case ErrCode of
    0: ShowMessage('Не хватает памяти или ресурсов');
    ERROR_BAD_FORMAT:
       ShowMessage('Ошибочный файл '+PName);
    ERROR_FILE_NOT_FOUND:
       ShowMessage('Не найден файл '+PName);
    ERROR_PATH_NOT_FOUND:
       ShowMessage('Не найден каталог '+ExtractFilePath(OpenDialog1.FileName));
    end;
  end;
end;


procedure TForm1.Button2Click(Sender: TObject);
VAR ErrCode:Integer;
    PName:Array [0..79] of char;
begin
  If OpenDialog1.Execute then
  begin
    ErrCode:=WinExec(StrPCopy(PName,OpenDialog1.FileName),SW_RESTORE);
    PName:=PName;
    Case ErrCode of
    0: ShowMessage('Не хватает памяти или ресурсов');
    ERROR_BAD_FORMAT:
       ShowMessage('Ошибочный файл '+PName);
    ERROR_FILE_NOT_FOUND:
       ShowMessage('Не найден файл '+PName);
    ERROR_PATH_NOT_FOUND:
       ShowMessage('Не найден каталог '+ExtractFilePath(OpenDialog1.FileName));
    end;
  end;
end;


procedure TForm1.Button3Click(Sender: TObject);
VAR ErrCode:Integer;
    PName:Array [0..79] of char;
begin
  If OpenDialog1.Execute then
  begin
    ErrCode:=WinExec(StrPCopy(PName,OpenDialog1.FileName),SW_RESTORE);
    PName:=PName;
    Case ErrCode of
    0: ShowMessage('Не хватает памяти или ресурсов');
    ERROR_BAD_FORMAT:
       ShowMessage('Ошибочный файл '+PName);
    ERROR_FILE_NOT_FOUND:
       ShowMessage('Не найден файл '+PName);
    ERROR_PATH_NOT_FOUND:
       ShowMessage('Не найден каталог '+ExtractFilePath(OpenDialog1.FileName));
    end;
  end;
end;



procedure TForm1.Button4Click(Sender: TObject);

begin
  //Очистка полей структуры StartInfo
  FillChar(StartInfo, Sizeof(StartInfo), #0);
  StartInfo.cb := Sizeof(StartInfo);
  CreateProcess(nil, 'F:\OS\ОС\5.1\project11.exe', nil,
    nil, False, NORMAL_PRIORITY_CLASS, nil, nil, StartInfo, ProcInfo);

    ErrCode:=WinExec('F:\OS\ОС\5.2\project2.exe',SW_RESTORE);
    PName:=PName;
    Case ErrCode of
    0: ShowMessage('Не хватает памяти или ресурсов');
    ERROR_BAD_FORMAT:
       ShowMessage('Ошибочный файл '+PName);
    ERROR_FILE_NOT_FOUND:
       ShowMessage('Не найден файл '+PName);
    ERROR_PATH_NOT_FOUND:
       ShowMessage('Не найден каталог '+ExtractFilePath(OpenDialog1.FileName));
    end;


  POperation:='open'+#0;
  PFilename:='F:\OS\ОС\5.3\project3.exe'+#0;
  ShellExecute(Handle,POperation,PFilename,nil,nil,SW_RESTORE);
end;

procedure TForm1.Button5Click(Sender: TObject);
begin
if SetPriorityClass(ProcInfo.hProcess,IDLE_PRIORITY_CLASS) then
  MessageBox(handle,'Выполнено','Выполнено',0)
  else  MessageBox(handle,'Ошибка','НЕвыполнено',0)
end;

end.

