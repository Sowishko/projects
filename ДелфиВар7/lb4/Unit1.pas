unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls;

type
  TForm1 = class(TForm)
    Edit1: TEdit;
    Label1: TLabel;
    Button1: TButton;
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


procedure TForm1.Button1Click(Sender: TObject);
  Var
hFile,hFileMap: Thandle;
lpFileName, pFile: PChar;
  Size, Size2, i,k: Integer;
simbolStr: string;
begin
  if Edit1.GetTextLen = 0 then
ShowMessage('Введите путь к файлу')
else
  begin
lpFileName:=Addr(Edit1.Text[1]);
hFile:=CreateFile(lpFileName,GENERIC_READ OR GENERIC_WRITE,
    FILE_SHARE_READ OR FILE_SHARE_WRITE, nil,
   OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, 0);
    If hFile=INVALID_HANDLE_VALUE then
    begin
ShowMessageFmt('Ошибка %d приоткрытиифайла ',[GetLastError]);
        exit;
    end;
    Size2:=GetFileSize(hFile,nil);
Size:=GetFileSize(hFile,nil)+30;
hFileMap:=CreateFileMapping(hFile,nil,PAGE_READWRITE,0,Size,nil);
    if hFileMap=INVALID_HANDLE_VALUE then
    begin
ShowMessageFmt('Ошибка %d при создании объекта "файл, проецируемый в память"',[GetlastError]);
CloseHandle(hFile);
       exit;
    end;
pFile:=MapViewOfFile(hFileMap,FILE_MAP_WRITE,0,0,0);
    If pFile=nil then
    begin
ShowMessageFmt('Ошибка %d припроецировании в память',[GetlastError]);
CloseHandle(hFile);
CloseHandle(hFileMap);
      exit;
    end;
i:=0;
    while i<Size do
    begin
      if i = 0 then
      begin
simbolStr:=pFile[i];
simbolStr:=AnsiUpperCase(simbolStr);
pFile[i]:=simbolStr[1];
      end;
      if(pFile[i]=' ') then
      begin
simbolStr:=pFile[i+1];
simbolStr:=AnsiUpperCase(simbolStr);
pFile[i+1]:=simbolStr[1];
      end;
      if i+2 < Size then
      begin
        if (pFile[i]='.') and (pFile[i+1]='.') and (pFile[i+2]='.') then i:=i+2;
      end;
      if (pFile[i]='.') or (pFile[i]='!') or (pFile[i]='?') then
      begin
         for k:=GetFileSize(hFile,nil)+1 downto i+1 do
         begin
if(k = i+1) then pFile[k]:=' ' else   pFile[k]:=pFile[k-1];
         end;
         for k:=GetFileSize(hFile,nil)+1 downto i+2 do
         begin
if(k = i+2) then pFile[k]:=' ' else   pFile[k]:=pFile[k-1];
         end;
pFile[i+1]:=#13;
pFile[i+2]:=#10;
         while (pFile[i+3]=' ') do
         begin
           for k:=i+3 to GetFileSize(hFile,nil)+1 do
           begin
              if k = GetFileSize(hFile,nil)+1 then pFile[k]:=' ' else pFile[k]:=pFile[k+1];
           end;
         end;
simbolStr:=pFile[i+3];
simbolStr:=AnsiUpperCase(simbolStr);
pFile[i+3]:=simbolStr[1];
      end;
      Inc(i);
    end;
UnMapViewOfFile(pFile);
CloseHandle(hFile);
CloseHandle(hFileMap);
  end;
end;
end.

