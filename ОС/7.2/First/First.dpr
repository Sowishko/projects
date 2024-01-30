program First;

uses
  Forms,
  Unit1 in 'Unit1.pas' {First1};

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TFirst1, First1);
  Application.Run;
end.
