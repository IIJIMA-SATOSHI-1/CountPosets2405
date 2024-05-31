n元に入る順序集合を列挙、数え上げるプログラムを思いついたので作った。
n元集合の異なる2元の関係を-1,0,1を成分に持つ上半三角行列で表す。
x<yの時        a_x,y=1
xとyが関係ない  a_x,y=0
x>yの時        a_x,y=-1

a_x,xは同じ元なのでこのどれでもないが、表さないで問題ない。（反射律）
下半分は、上半分と逆の関係になるので表す必要はない。（反対称律）

すべての-1,0,1パターンを生成して、推移律を満たさないものがあるので取り除けば半順序集合になる。

The On-Line Encyclopedia of Integer Sequences (OEIS)
https://oeis.org/A001035
A001035		Number of partially ordered sets ("posets") with n labeled elements (or labeled acyclic transitive digraphs).
1, 3, 19, 219, 4231, 130023, 6129859…
と一致することが確認できた。

> .\CountPosets2405.exe
Number of posets of 4 elements :        219
Number of three types of relation of 4 elements (3^(4*3/2)):    729
> .\CountPosets2405.exe 5
Number of posets of 5 elements :        4231
Number of three types of relation of 5 elements (3^(5*4/2)):    59049
> .\CountPosets2405.exe 6
Number of posets of 6 elements :        130023
Number of three types of relation of 6 elements (3^(6*5/2)):    14348907
> .\CountPosets2405.exe 7
Number of posets of 7 elements :        6129859
Number of three types of relation of 7 elements (3^(7*6/2)):    1870418611

Printのところコメントアウトを外すと、具体的に表示して列挙する。
n=3 についての例
                -1      -1
                        -1

                -1      -1
                        0

                -1      -1
                        1

                -1      0
                        0

                -1      0
                        1

                -1      1
                        1

                0       -1
                        -1

                0       -1
                        0

                0       0
                        -1

                0       0
                        0

                0       0
                        1

                0       1
                        0

                0       1
                        1

                1       -1
                        -1

                1       0
                        -1

                1       0
                        0

                1       1
                        -1

                1       1
                        0

                1       1
                        1
