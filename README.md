# LyricsExporter

音声ファイルのメタデータから歌詞タグを取り出し、`get_lyrics.txt` に書き出す小さな Windows 向けツールです。

## 概要

`LyricsExporter.exe` に音声ファイルのパスを起動引数として渡すと、TagLibSharp でファイルを読み込み、タグに含まれる歌詞をテキストファイルへ出力します。

- 対象: TagLibSharp が読み取れる音声ファイル
- 出力先: 実行ファイルと同じフォルダの `get_lyrics.txt`
- 歌詞タグがない場合: 空文字または空ファイル相当の内容になります
- 引数なしで起動した場合: `get_lyrics.txt` を空にして終了します

## 必要環境

- Windows
- .NET 10 Runtime

開発・ビルドには .NET SDK が必要です。

## 使い方

```powershell
LyricsExporter.exe "C:\Music\sample.mp3"
```

実行後、`LyricsExporter.exe` と同じフォルダに `get_lyrics.txt` が作成または上書きされます。

例:

```text
LyricsExporter.exe
get_lyrics.txt
```

## ビルド

リポジトリのルートで次を実行します。

```powershell
dotnet build .\LyricsExporter\LyricsExporter.csproj
```

## 公開

公開プロファイルを使う場合:

```powershell
dotnet publish .\LyricsExporter\LyricsExporter.csproj /p:PublishProfile=FolderProfile
```

出力先は公開プロファイル上では次のフォルダです。

```text
LyricsExporter\bin\Release\net10.0-windows7.0\publish\win-x64\
```

## 主な依存関係

- [TagLibSharp](https://github.com/mono/taglib-sharp): 音声ファイルのタグ読み取り
- Costura.Fody: 依存 DLL の埋め込み

## 注意

このアプリは通常の画面操作用 GUI ではなく、外部ツールやスクリプトからファイルパスを渡して使う想定のユーティリティです。出力ファイルは毎回上書きされます。
