unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls;

type
  TForm1 = class(TForm)
    Label1: TLabel;
    Edit1: TEdit;
    Button1: TButton;
    Memo1: TMemo;
    Label2: TLabel;
    Label3: TLabel;
    Edit2: TEdit;
    Label4: TLabel;
    Edit3: TEdit;
    Memo2: TMemo;
    Label5: TLabel;
    Edit4: TEdit;
    Label6: TLabel;
    procedure Button1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
//Дескриптор потока, создающего поток Thread2
  hThread2:THandle;  
// Массив потоков обслуживания запросов клиентов
  hThread1:Array[0..1000] of THandle;
  hThread3:Array[0..1000] of THandle;
// Идентификаторы соответствующих потоков
  ThreadId2:DWORD;
  ThreadId1:Array[0..1000] of DWORD;
  ThreadId3:Array[0..1000] of DWORD;
// Дескриптор семафора
  serv1,serv2:tHandle;
// Номер очередного поступившего запроса
  q:Integer;
// Максимально допустимое число запросов
  zapr:Integer;


implementation

{$R *.dfm}



procedure Thread1;
Var q1:Integer;
Begin
// Запомнить номер очередного обрабатываемого запроса
  q1:=q;
// Если сервер свободен , запрос обрабатывается
  WaitForSingleObject(serv1,INFINITE);
// Запрос обрабатывается при условии,
// что номер запроса  - положительное число
   If q1>0 then
   Begin
// Случайное время выполнения звапроса
     Sleep(1000+Random(2000));
// Вывод информации о завершении обработки запроса с номером q1
     Form1.Memo1.Lines.Add('Обработан запрос номер '+IntToStr(q1));
    end;
// Сервер освобождается для обработки других запросов
ReleaseSemaphore(serv1,1,nil);
end;

procedure Thread3;
Var q3:Integer;
Begin
// Запомнить номер очередного обрабатываемого запроса
  q3:=q;
// Если сервер свободен , запрос обрабатывается
  WaitForSingleObject(serv2,INFINITE);
// Запрос обрабатывается при условии,
// что номер запроса  - положительное число
   If q3>0 then
   Begin
// Случайное время выполнения звапроса
     Sleep(1000+Random(2000));
// Вывод информации о завершении обработки запроса с номером q1
     Form1.Memo2.Lines.Add('Обработан запрос номер '+IntToStr(q3));
    end;
// Сервер освобождается для обработки других запросов
ReleaseSemaphore(serv2,1,nil);
end;

procedure Thread2;
begin
// Создается очередной запрос, если общее число созданных запросов
// меньше числа zapr, вводимого с клавиатуры
  While q<zapr do
  Begin
// Запросы поступают через случайный интервал времени
      Sleep(100+Random(200));
// Увеличиваем на 1 число поступивших запросов
      q:=q+1;
      Form1.Edit3.Text:=IntToStr(q);
// Создаем поток, для обслуживания поступившего запроса
      if (q mod 2 = 0) then
      begin
        hThread1[q]:=CreateThread(nil,0,@Thread1,nil,0,ThreadID1[q]);
      end
      else
      begin
        hThread3[q]:=CreateThread(nil,0,@Thread3,nil,0,ThreadID3[q]);
      end;
  end;
end;

procedure TForm1.Button1Click(Sender: TObject);
Var
  res,res2:Integer;
begin
  Memo1.Clear;
  Memo2.Clear;
// очищаем счетчик числа поступивших запросов
  q:=0;
// ввод числа одновременно обслуживаемых на сервере запросов
// это число требуется для настройки семафора
  res:=StrToInt(Edit1.text);
  res2:=StrToInt(Edit4.text);
// ввод максимального числа запросов
  zapr:=StrToInt(Edit2.text);
// создание семафора
  serv1:=CreateSemaphore(nil,res,res,nil);
  serv2:=CreateSemaphore(nil,res2,res2,nil);
// создание потока, предназначенного для приема запросов клиентов
  hThread2:=CreateThread(nil,0,@Thread2,nil,0,ThreadID2);
end;



end.

