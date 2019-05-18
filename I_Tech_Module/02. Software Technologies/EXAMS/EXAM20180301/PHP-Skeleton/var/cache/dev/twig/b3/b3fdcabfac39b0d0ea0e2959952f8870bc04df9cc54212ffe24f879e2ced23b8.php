<?php

/* @Twig/layout.html.twig */
class __TwigTemplate_0ef46ff3e00be850b375145c4de69a72941605b1b30816a42d1a36aa92bc080f extends Twig_Template
{
    public function __construct(Twig_Environment $env)
    {
        parent::__construct($env);

        $this->parent = false;

        $this->blocks = array(
            'title' => array($this, 'block_title'),
            'head' => array($this, 'block_head'),
            'body' => array($this, 'block_body'),
        );
    }

    protected function doDisplay(array $context, array $blocks = array())
    {
        $__internal_5673176c8bf7d4f043826b97bb47461a8f9d4f90c2ce59e42433e3e40468c55e = $this->env->getExtension("Symfony\\Bundle\\WebProfilerBundle\\Twig\\WebProfilerExtension");
        $__internal_5673176c8bf7d4f043826b97bb47461a8f9d4f90c2ce59e42433e3e40468c55e->enter($__internal_5673176c8bf7d4f043826b97bb47461a8f9d4f90c2ce59e42433e3e40468c55e_prof = new Twig_Profiler_Profile($this->getTemplateName(), "template", "@Twig/layout.html.twig"));

        $__internal_71cd0d2c97d32b42ba7f9bc5b87a711aca9b3efb2da9bd1b89655fd2afbc3e03 = $this->env->getExtension("Symfony\\Bridge\\Twig\\Extension\\ProfilerExtension");
        $__internal_71cd0d2c97d32b42ba7f9bc5b87a711aca9b3efb2da9bd1b89655fd2afbc3e03->enter($__internal_71cd0d2c97d32b42ba7f9bc5b87a711aca9b3efb2da9bd1b89655fd2afbc3e03_prof = new Twig_Profiler_Profile($this->getTemplateName(), "template", "@Twig/layout.html.twig"));

        // line 1
        echo "<!DOCTYPE html>
<html>
    <head>
        <meta charset=\"";
        // line 4
        echo twig_escape_filter($this->env, $this->env->getCharset(), "html", null, true);
        echo "\" />
        <meta name=\"robots\" content=\"noindex,nofollow\" />
        <meta name=\"viewport\" content=\"width=device-width,initial-scale=1\" />
        <title>";
        // line 7
        $this->displayBlock('title', $context, $blocks);
        echo "</title>
        <link rel=\"icon\" type=\"image/png\" href=\"";
        // line 8
        echo twig_include($this->env, $context, "@Twig/images/favicon.png.base64");
        echo "\">
        <style>";
        // line 9
        echo twig_include($this->env, $context, "@Twig/exception.css.twig");
        echo "</style>
        ";
        // line 10
        $this->displayBlock('head', $context, $blocks);
        // line 11
        echo "    </head>
    <body>
        <header>
            <div class=\"container\">
                <h1 class=\"logo\">";
        // line 15
        echo twig_include($this->env, $context, "@Twig/images/symfony-logo.svg");
        echo " Symfony Exception</h1>

                <div class=\"help-link\">
                    <a href=\"https://symfony.com/doc\">
                        <span class=\"icon\">";
        // line 19
        echo twig_include($this->env, $context, "@Twig/images/icon-book.svg");
        echo "</span>
                        <span class=\"hidden-xs-down\">Symfony</span> Docs
                    </a>
                </div>

                <div class=\"help-link\">
                    <a href=\"https://symfony.com/support\">
                        <span class=\"icon\">";
        // line 26
        echo twig_include($this->env, $context, "@Twig/images/icon-support.svg");
        echo "</span>
                        <span class=\"hidden-xs-down\">Symfony</span> Support
                    </a>
                </div>
            </div>
        </header>

        ";
        // line 33
        $this->displayBlock('body', $context, $blocks);
        // line 34
        echo "        ";
        echo twig_include($this->env, $context, "@Twig/base_js.html.twig");
        echo "
    </body>
</html>
";
        
        $__internal_5673176c8bf7d4f043826b97bb47461a8f9d4f90c2ce59e42433e3e40468c55e->leave($__internal_5673176c8bf7d4f043826b97bb47461a8f9d4f90c2ce59e42433e3e40468c55e_prof);

        
        $__internal_71cd0d2c97d32b42ba7f9bc5b87a711aca9b3efb2da9bd1b89655fd2afbc3e03->leave($__internal_71cd0d2c97d32b42ba7f9bc5b87a711aca9b3efb2da9bd1b89655fd2afbc3e03_prof);

    }

    // line 7
    public function block_title($context, array $blocks = array())
    {
        $__internal_1837f634a5eb0a82716695e35ca967ea197b9f8e22f336309ea8fcd3d490b67b = $this->env->getExtension("Symfony\\Bundle\\WebProfilerBundle\\Twig\\WebProfilerExtension");
        $__internal_1837f634a5eb0a82716695e35ca967ea197b9f8e22f336309ea8fcd3d490b67b->enter($__internal_1837f634a5eb0a82716695e35ca967ea197b9f8e22f336309ea8fcd3d490b67b_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "title"));

        $__internal_5797e3276901269793ba0bd5570acc7c9c0eeea73a07e2821850bd040c650370 = $this->env->getExtension("Symfony\\Bridge\\Twig\\Extension\\ProfilerExtension");
        $__internal_5797e3276901269793ba0bd5570acc7c9c0eeea73a07e2821850bd040c650370->enter($__internal_5797e3276901269793ba0bd5570acc7c9c0eeea73a07e2821850bd040c650370_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "title"));

        
        $__internal_5797e3276901269793ba0bd5570acc7c9c0eeea73a07e2821850bd040c650370->leave($__internal_5797e3276901269793ba0bd5570acc7c9c0eeea73a07e2821850bd040c650370_prof);

        
        $__internal_1837f634a5eb0a82716695e35ca967ea197b9f8e22f336309ea8fcd3d490b67b->leave($__internal_1837f634a5eb0a82716695e35ca967ea197b9f8e22f336309ea8fcd3d490b67b_prof);

    }

    // line 10
    public function block_head($context, array $blocks = array())
    {
        $__internal_2386fee11a84908ea946b63fd48736134f14ac065ec9b4f5ed58868d4c077605 = $this->env->getExtension("Symfony\\Bundle\\WebProfilerBundle\\Twig\\WebProfilerExtension");
        $__internal_2386fee11a84908ea946b63fd48736134f14ac065ec9b4f5ed58868d4c077605->enter($__internal_2386fee11a84908ea946b63fd48736134f14ac065ec9b4f5ed58868d4c077605_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "head"));

        $__internal_13614896e6c852f8b86d55f26c299af4161c8246f73dfd2d911e6c462e98523c = $this->env->getExtension("Symfony\\Bridge\\Twig\\Extension\\ProfilerExtension");
        $__internal_13614896e6c852f8b86d55f26c299af4161c8246f73dfd2d911e6c462e98523c->enter($__internal_13614896e6c852f8b86d55f26c299af4161c8246f73dfd2d911e6c462e98523c_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "head"));

        
        $__internal_13614896e6c852f8b86d55f26c299af4161c8246f73dfd2d911e6c462e98523c->leave($__internal_13614896e6c852f8b86d55f26c299af4161c8246f73dfd2d911e6c462e98523c_prof);

        
        $__internal_2386fee11a84908ea946b63fd48736134f14ac065ec9b4f5ed58868d4c077605->leave($__internal_2386fee11a84908ea946b63fd48736134f14ac065ec9b4f5ed58868d4c077605_prof);

    }

    // line 33
    public function block_body($context, array $blocks = array())
    {
        $__internal_ed92232bd90e0c34828b939bc16940095b117d7d35d7ac5001fc5b86b2122da3 = $this->env->getExtension("Symfony\\Bundle\\WebProfilerBundle\\Twig\\WebProfilerExtension");
        $__internal_ed92232bd90e0c34828b939bc16940095b117d7d35d7ac5001fc5b86b2122da3->enter($__internal_ed92232bd90e0c34828b939bc16940095b117d7d35d7ac5001fc5b86b2122da3_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "body"));

        $__internal_dfd3f8ac7bb899417727e6830f150333d0f0e1cde46687045cf1471274457734 = $this->env->getExtension("Symfony\\Bridge\\Twig\\Extension\\ProfilerExtension");
        $__internal_dfd3f8ac7bb899417727e6830f150333d0f0e1cde46687045cf1471274457734->enter($__internal_dfd3f8ac7bb899417727e6830f150333d0f0e1cde46687045cf1471274457734_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "body"));

        
        $__internal_dfd3f8ac7bb899417727e6830f150333d0f0e1cde46687045cf1471274457734->leave($__internal_dfd3f8ac7bb899417727e6830f150333d0f0e1cde46687045cf1471274457734_prof);

        
        $__internal_ed92232bd90e0c34828b939bc16940095b117d7d35d7ac5001fc5b86b2122da3->leave($__internal_ed92232bd90e0c34828b939bc16940095b117d7d35d7ac5001fc5b86b2122da3_prof);

    }

    public function getTemplateName()
    {
        return "@Twig/layout.html.twig";
    }

    public function isTraitable()
    {
        return false;
    }

    public function getDebugInfo()
    {
        return array (  137 => 33,  120 => 10,  103 => 7,  88 => 34,  86 => 33,  76 => 26,  66 => 19,  59 => 15,  53 => 11,  51 => 10,  47 => 9,  43 => 8,  39 => 7,  33 => 4,  28 => 1,);
    }

    /** @deprecated since 1.27 (to be removed in 2.0). Use getSourceContext() instead */
    public function getSource()
    {
        @trigger_error('The '.__METHOD__.' method is deprecated since version 1.27 and will be removed in 2.0. Use getSourceContext() instead.', E_USER_DEPRECATED);

        return $this->getSourceContext()->getCode();
    }

    public function getSourceContext()
    {
        return new Twig_Source("<!DOCTYPE html>
<html>
    <head>
        <meta charset=\"{{ _charset }}\" />
        <meta name=\"robots\" content=\"noindex,nofollow\" />
        <meta name=\"viewport\" content=\"width=device-width,initial-scale=1\" />
        <title>{% block title %}{% endblock %}</title>
        <link rel=\"icon\" type=\"image/png\" href=\"{{ include('@Twig/images/favicon.png.base64') }}\">
        <style>{{ include('@Twig/exception.css.twig') }}</style>
        {% block head %}{% endblock %}
    </head>
    <body>
        <header>
            <div class=\"container\">
                <h1 class=\"logo\">{{ include('@Twig/images/symfony-logo.svg') }} Symfony Exception</h1>

                <div class=\"help-link\">
                    <a href=\"https://symfony.com/doc\">
                        <span class=\"icon\">{{ include('@Twig/images/icon-book.svg') }}</span>
                        <span class=\"hidden-xs-down\">Symfony</span> Docs
                    </a>
                </div>

                <div class=\"help-link\">
                    <a href=\"https://symfony.com/support\">
                        <span class=\"icon\">{{ include('@Twig/images/icon-support.svg') }}</span>
                        <span class=\"hidden-xs-down\">Symfony</span> Support
                    </a>
                </div>
            </div>
        </header>

        {% block body %}{% endblock %}
        {{ include('@Twig/base_js.html.twig') }}
    </body>
</html>
", "@Twig/layout.html.twig", "H:\\EXAM\\PHP-Skeleton\\vendor\\symfony\\symfony\\src\\Symfony\\Bundle\\TwigBundle\\Resources\\views\\layout.html.twig");
    }
}
