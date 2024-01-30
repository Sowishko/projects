object Form1: TForm1
  Left = 192
  Top = 124
  Width = 175
  Height = 179
  Caption = 'Form1'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object Label1: TLabel
    Left = 0
    Top = 88
    Width = 55
    Height = 13
    Caption = #1055#1088#1080#1086#1088#1080#1090#1077#1090
  end
  object Button1: TButton
    Left = 0
    Top = 0
    Width = 153
    Height = 25
    Caption = #1047#1072#1087#1091#1089#1090#1080#1090#1100' '#1082#1072#1083#1100#1082#1091#1083#1103#1090#1086#1088
    TabOrder = 0
    OnClick = Button1Click
  end
  object ComboBox1: TComboBox
    Left = 0
    Top = 32
    Width = 153
    Height = 21
    ItemHeight = 13
    TabOrder = 1
    Items.Strings = (
      'Idle'
      'Normal'
      'High'
      'Real time')
  end
  object Button2: TButton
    Left = 0
    Top = 56
    Width = 153
    Height = 25
    Caption = #1048#1079#1084#1077#1085#1080#1090#1100' '#1087#1088#1080#1086#1088#1080#1090#1077#1090
    TabOrder = 2
    OnClick = Button2Click
  end
  object Edit1: TEdit
    Left = 56
    Top = 88
    Width = 97
    Height = 21
    TabOrder = 3
    Text = 'Edit1'
  end
  object Button3: TButton
    Left = 80
    Top = 112
    Width = 75
    Height = 25
    Caption = #1042#1099#1093#1086#1076
    TabOrder = 4
    OnClick = Button3Click
  end
  object Button4: TButton
    Left = 0
    Top = 112
    Width = 75
    Height = 25
    Caption = #1047#1072#1082#1088#1099#1090#1100
    TabOrder = 5
    OnClick = Button4Click
  end
end
