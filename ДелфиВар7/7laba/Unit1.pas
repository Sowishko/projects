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
//���������� ������, ���������� ����� Thread2
  hThread2:THandle;  
// ������ ������� ������������ �������� ��������
  hThread1:Array[0..1000] of THandle;
  hThread3:Array[0..1000] of THandle;
// �������������� ��������������� �������
  ThreadId2:DWORD;
  ThreadId1:Array[0..1000] of DWORD;
  ThreadId3:Array[0..1000] of DWORD;
// ���������� ��������
  serv1,serv2:tHandle;
// ����� ���������� ������������ �������
  q:Integer;
// ����������� ���������� ����� ��������
  zapr:Integer;


implementation

{$R *.dfm}



procedure Thread1;
Var q1:Integer;
Begin
// ��������� ����� ���������� ��������������� �������
  q1:=q;
// ���� ������ �������� , ������ ��������������
  WaitForSingleObject(serv1,INFINITE);
// ������ �������������� ��� �������,
// ��� ����� �������  - ������������� �����
   If q1>0 then
   Begin
// ��������� ����� ���������� ��������
     Sleep(1000+Random(2000));
// ����� ���������� � ���������� ��������� ������� � ������� q1
     Form1.Memo1.Lines.Add('��������� ������ ����� '+IntToStr(q1));
    end;
// ������ ������������� ��� ��������� ������ ��������
ReleaseSemaphore(serv1,1,nil);
end;

procedure Thread3;
Var q3:Integer;
Begin
// ��������� ����� ���������� ��������������� �������
  q3:=q;
// ���� ������ �������� , ������ ��������������
  WaitForSingleObject(serv2,INFINITE);
// ������ �������������� ��� �������,
// ��� ����� �������  - ������������� �����
   If q3>0 then
   Begin
// ��������� ����� ���������� ��������
     Sleep(1000+Random(2000));
// ����� ���������� � ���������� ��������� ������� � ������� q1
     Form1.Memo2.Lines.Add('��������� ������ ����� '+IntToStr(q3));
    end;
// ������ ������������� ��� ��������� ������ ��������
ReleaseSemaphore(serv2,1,nil);
end;

procedure Thread2;
begin
// ��������� ��������� ������, ���� ����� ����� ��������� ��������
// ������ ����� zapr, ��������� � ����������
  While q<zapr do
  Begin
// ������� ��������� ����� ��������� �������� �������
      Sleep(100+Random(200));
// ����������� �� 1 ����� ����������� ��������
      q:=q+1;
      Form1.Edit3.Text:=IntToStr(q);
// ������� �����, ��� ������������ ������������ �������
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
// ������� ������� ����� ����������� ��������
  q:=0;
// ���� ����� ������������ ������������� �� ������� ��������
// ��� ����� ��������� ��� ��������� ��������
  res:=StrToInt(Edit1.text);
  res2:=StrToInt(Edit4.text);
// ���� ������������� ����� ��������
  zapr:=StrToInt(Edit2.text);
// �������� ��������
  serv1:=CreateSemaphore(nil,res,res,nil);
  serv2:=CreateSemaphore(nil,res2,res2,nil);
// �������� ������, ���������������� ��� ������ �������� ��������
  hThread2:=CreateThread(nil,0,@Thread2,nil,0,ThreadID2);
end;



end.

