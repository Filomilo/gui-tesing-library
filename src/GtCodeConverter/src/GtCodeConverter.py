import typing

from LanguageTypes import LANGUAGES


class GtCodeConverter:
  def  CreateWrappings(lang: LANGUAGES, srcLoacation: str, outLocation: str):
      CppFiles: str[] = GetAllCppFiles(srcLoacation)