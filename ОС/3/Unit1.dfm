object Form1: TForm1
  Left = 192
  Top = 124
  Width = 553
  Height = 675
  Caption = 'Form1'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  OnActivate = FormActivate
  PixelsPerInch = 96
  TextHeight = 13
  object Label1: TLabel
    Left = 272
    Top = 16
    Width = 79
    Height = 13
    Caption = #1050#1086#1083'-'#1074#1086' '#1089#1090#1088#1072#1085#1080#1094
  end
  object Button1: TButton
    Left = 8
    Top = 8
    Width = 75
    Height = 25
    Caption = #1042#1099#1095#1080#1089#1083#1080#1090#1100
    TabOrder = 0
    OnClick = Button1Click
  end
  object Edit1: TEdit
    Left = 88
    Top = 8
    Width = 169
    Height = 21
    TabOrder = 1
  end
  object Memo1: TMemo
    Left = 8
    Top = 40
    Width = 201
    Height = 593
    Lines.Strings = (
      'Memo1')
    TabOrder = 2
  end
  object Memo2: TMemo
    Left = 216
    Top = 40
    Width = 201
    Height = 593
    Lines.Strings = (
      'Memo2')
    TabOrder = 3
    Visible = False
  end
  object Edit2: TEdit
    Left = 368
    Top = 8
    Width = 49
    Height = 21
    TabOrder = 4
  end
end
