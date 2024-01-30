object Form1: TForm1
  Left = 234
  Top = 107
  Width = 1305
  Height = 675
  Caption = 'Form1'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 13
  object Button1: TButton
    Left = 360
    Top = 272
    Width = 75
    Height = 25
    Caption = #1042#1099#1093#1086#1076
    TabOrder = 0
    OnClick = Button1Click
  end
  object StringGrid1: TStringGrid
    Left = 0
    Top = 0
    Width = 353
    Height = 297
    TabOrder = 1
    OnClick = StringGrid1Click
  end
  object StringGrid2: TStringGrid
    Left = 440
    Top = 0
    Width = 320
    Height = 297
    ColCount = 2
    TabOrder = 2
  end
end
