unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls;

type
  TForm1 = class(TForm)
    Label2: TLabel;
    LetterField: TEdit;
    MemoTextWin: TMemo;
    Label3: TLabel;
    Button1: TButton;
    Edit1: TEdit;
    procedure FormCreate(Sender: TObject);
    procedure Button1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
begin
  MemoTextWin.Clear();
end;

procedure TForm1.Button1Click(Sender: TObject);
var
  hFile, hFileMap: THandle;
  pFile, Str: PChar;
  Size, i, j, z: Integer;
  Letter: Char;
  TextStr: string;
  counter: integer;
begin
  hFile := CreateFile('file1.txt', GENERIC_READ or GENERIC_WRITE,
    FILE_SHARE_READ or FILE_SHARE_WRITE, nil,
    OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, 0);
  if hFile = INVALID_HANDLE_VALUE then
  begin
    ShowMessageFmt('Ошибка %d при открытии файла ', [GetLastError]);
    exit;
  end;
  Size := GetFileSize(hFile, nil);
  hFileMap := CreateFileMapping(hFile, nil, PAGE_READWRITE, 0, Size, nil);
  if hFileMap = INVALID_HANDLE_VALUE then
  begin
    ShowMessageFmt('Ошибка %d при создании объекта "файл,  проецируемый в память"', [GetlastError]);
    CloseHandle(hFile);
    exit;
  end;
  pFile := MapViewOfFile(hFileMap, FILE_MAP_WRITE, 0, 0, 0);
  if pFile = nil then
  begin
    ShowMessageFmt('Ошибка %d при проецировании в память', [GetlastError]);
    CloseHandle(hFile);
    CloseHandle(hFileMap);
    exit;
  end;

  if LetterField.GetTextLen <> 1 then
    ShowMessage('Введите одну символ!')
  else
  begin
    counter:=0;
    TextStr := LetterField.Text;
    Letter := TextStr[1];
    i := 0;
    for z:=0 to Size do
     begin
        if pFile[z] = Letter   then
        begin
          Inc(counter);
        end;
     end;
    Edit1.Text := IntToStr(counter);
    while (i <= Size) do
    begin
      while pFile[i] = Letter do
      begin
        j := i;
        while j <= Size - 1 do
        begin
          pFile[j] := pFile[j + 1];
          Inc(j);
        end;
      end;
      Inc(i);
    end;
    MemoTextWin.Lines.Add(pFile);
    UnMapViewOfFile(pFile);
    CloseHandle(hFile);
    CloseHandle(hFileMap);
  end;
end;

end.
{if pFile[i] = Letter then
begin
  j := i;
  while j <= Size - 1 do
  begin
    pFile[j] := pFile[j + 1];
    Inc(j);
  end;

end;    }

